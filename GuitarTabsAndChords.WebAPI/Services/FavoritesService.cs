using AutoMapper;
using GuitarTabsAndChords.Model;
using GuitarTabsAndChords.Model.Requests;
using GuitarTabsAndChords.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarTabsAndChords.WebAPI.Services
{
    public class FavoritesService : IFavoritesService
    {
        private readonly GuitarTabsContext _context;
        private readonly IMapper _mapper;

        public FavoritesService(GuitarTabsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.Favorites> Get(FavoritesSearchRequest request)
        {
            var query = _context.Favorites.AsQueryable();

            if (request?.NotationId != 0)
                query = query.Where(x => x.NotationId == request.NotationId);

            query = query.Where(x => x.UserId == 1); // todo

            query = query.Include(x => x.Notation.User);
            query = query.Include(x => x.Notation.Song.Artist);

            var list = query.ToList();

            return _mapper.Map<List<Model.Favorites>>(list);
        }

        public Model.Favorites GetById(int id)
        {
            var entity = _context.Favorites
                .Where(x => x.NotationId == id)
                .Where(x => x.UserId == 1) // todo
                .FirstOrDefault();

            return _mapper.Map<Model.Favorites>(entity);
        }

        public bool Delete(int id)
        {
            Database.Favorites entity = _context.Favorites
                .Where(x => x.NotationId == id)
                .Where(x => x.UserId == 1) // todo
                .FirstOrDefault();

            if (entity != null)
            {
                _context.Favorites.Remove(entity);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public Model.Favorites Insert(FavoritesInsertRequest request)
        {
            int UserId = 1; // todo

            var existingEntity = _context.Favorites.Where(x => x.NotationId == request.NotationId && x.UserId == UserId).FirstOrDefault();
            if (existingEntity != null)
            {
                return _mapper.Map<Model.Favorites>(existingEntity);
            }

            Database.Favorites entity = _mapper.Map<Database.Favorites>(request);
            entity.UserId = UserId;
            _context.Favorites.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Favorites>(entity);
        }
    }
}
