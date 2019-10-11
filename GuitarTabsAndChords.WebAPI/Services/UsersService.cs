using AutoMapper;
using GuitarTabsAndChords.Model;
using GuitarTabsAndChords.Model.Requests;
using GuitarTabsAndChords.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GuitarTabsAndChords.WebAPI.Services
{
    public class UsersService : IUsersService
    {
        private readonly GuitarTabsContext _context;
        private readonly IMapper _mapper;

        private Model.Users _currentUser;

        public UsersService(GuitarTabsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.Users> Get(UsersSearchRequest request)
        {
            var query = _context.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Search))
                query = query.Where(x => x.Username.Contains(request.Search) ||
                x.Email.Contains(request.Search) ||
                x.Name.Contains(request.Search) ||
                x.LastName.Contains(request.Search)
                );

            query = query.Include(x => x.Role);
            var list = query.ToList();

            return _mapper.Map<List<Model.Users>>(list);
        }

        public Model.Users GetById(int id)
        {
            var entity = _context.Users.Where(x => x.Id == id).Include(x => x.Role).FirstOrDefault();


            return _mapper.Map<Model.Users>(entity);
        }

        public Model.Users Insert(UsersInsertRequest request)
        {
            var entity = _mapper.Map<Database.Users>(request);
            if (request.Password != request.PasswordConfirmation)
            {
                throw new Exception("Passwords do not match");
            }

            entity.PasswordSalt = GenerateSalt();
            entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.Password);
            entity.RoleId = _context.Roles.Where(x => x.Name == "User").FirstOrDefault().Id;
            entity.DateRegistered = DateTime.Now;

            _context.Users.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Users>(entity);
        }

        public Model.Users InsertAdmin(UsersInsertRequest request)
        {
            var entity = _mapper.Map<Database.Users>(request);
            if (request.Password != request.PasswordConfirmation)
            {
                throw new Exception("Passwords do not match");
            }

            entity.PasswordSalt = GenerateSalt();
            entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.Password);
            entity.RoleId = _context.Roles.Where(x => x.Name == "Administrator").FirstOrDefault().Id;
            entity.DateRegistered = DateTime.Now;

            _context.Users.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Users>(entity);
        }

        public Model.Users Update(int id, UsersUpdateRequest request)
        {
            var entity = _context.Users.Find(id);

            _context.Users.Attach(entity);
            _context.Users.Update(entity);
            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                if (request.Password != request.PasswordConfirmation)
                {
                    throw new Exception("Passwordi se ne slažu");
                }

                entity.PasswordSalt = GenerateSalt();
                entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.Password);
            }

            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<Model.Users>(entity);
        }


        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        public Model.Users MyProfile()
        {
            var query = _context.Users.AsQueryable();

            query = query.Where(x => x.Id == _currentUser.Id);

            query = query.Include(x => x.Role);

            var entity = query.FirstOrDefault();

            return _mapper.Map<Model.Users>(entity);
        }

        public Model.Users Authenticate(string username, string pass)
        {
            var user = _context.Users
                         .Include(x => x.Role)
                         .FirstOrDefault(x => x.Username == username);

            if (user != null)
            {
                var newHash = GenerateHash(user.PasswordSalt, pass);

                if (newHash == user.PasswordHash)
                {
                    return _mapper.Map<Model.Users>(user);
                }
            }
            return null;
        }

        public void SetCurrentUser(Model.Users user)
        {
            _currentUser = user;
        }
        public Model.Users GetCurrentUser()
        {
            return _currentUser;
        }
    }
}
