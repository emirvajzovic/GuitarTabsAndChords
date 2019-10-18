using AutoMapper;
using GuitarTabsAndChords.Model;
using GuitarTabsAndChords.Model.Requests;
using GuitarTabsAndChords.WebAPI.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarTabsAndChords.WebAPI.Services
{
    public class AlbumsService: IAlbumsService
    {
        private readonly GuitarTabsContext _context;
        private readonly IMapper _mapper;
        private readonly IUsersService _usersService;

        public AlbumsService(GuitarTabsContext context, IMapper mapper, IUsersService usersService)
        {
            _context = context;
            _mapper = mapper;
            _usersService = usersService;
        }

        public List<Model.Albums> Get(AlbumsSearchRequest request)
        {
            var query = _context.Albums.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Name))
                query = query.Where(x => x.Name.Contains(request.Name));
            if (request?.Year != 0)
                query = query.Where(x => x.Year == request.Year);
            if (request?.ArtistId != 0)
                query = query.Where(x => x.ArtistId == request.ArtistId);
            if (request?.Decade != 0)
                query = query.Where(x => x.Year >= request.Decade / 10 * 10 && x.Year <= request.Decade / 10 * 10 + 9);
            query = query.Include(x => x.Artist);

            if (request.Filter.HasValue)
            {
                if (request.Filter.Value == (int)ReviewStatus.FilterPendingApproved)
                    query = query.Where(x => x.Status == ReviewStatus.Pending || x.Status == ReviewStatus.Approved);
                else
                    query = query.Where(x => (int)x.Status == request.Filter.Value);
            }

            var list = query.ToList();

            return _mapper.Map<List<Model.Albums>>(list);
        }

        public List<int> GetDecades()
        {
            return _context.Songs
                .Where(x => x.Year >= 1930)
                .Where(x=>x.Status == ReviewStatus.Approved)
                .Select(x => x.Year / 10 * 10)
                .Distinct()
                .OrderByDescending(x => x)
                .ToList();
        }

        public Model.Albums GetById(int id)
        {
            var entity = _context.Albums.Where(x => x.Id == id)
                .Include("Songs.Genre")
                .Include(x => x.Artist)
                .FirstOrDefault();

            return _mapper.Map<Model.Albums>(entity);
        }

        public Model.Albums Insert(AlbumsInsertRequest request)
        {
            var entity = _mapper.Map<Database.Albums>(request);

            if (_usersService.GetCurrentUser().Role.Name == "Administrator")
                entity.Status = ReviewStatus.Approved;
            else
                entity.Status = ReviewStatus.Pending;

            _context.Albums.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Albums>(entity);
        }

        public Model.Albums Update(int id, AlbumsInsertRequest request)
        {
            var entity = _context.Albums.Find(id);

            _context.Albums.Attach(entity);
            _context.Albums.Update(entity);

            if (request.Status == ReviewStatus.Rejected)
                entity.Status = ReviewStatus.Rejected;
            else
                _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<Model.Albums>(entity);
        }
    }
}
