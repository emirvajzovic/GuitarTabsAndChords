using AutoMapper;
using GuitarTabsAndChords.Model;
using GuitarTabsAndChords.Model.Requests;
using GuitarTabsAndChords.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarTabsAndChords.WebAPI.Services
{
    public class RatingsService: IRatingsService
    {
        private readonly GuitarTabsContext _context;
        private readonly IMapper _mapper;

        public RatingsService(GuitarTabsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.Ratings> Get(RatingsSearchRequest request)
        {
            var query = _context.Ratings.AsQueryable();

            if (request?.NotationId != 0)
                query = query.Where(x => x.NotationId == request.NotationId);

            query = query.Where(x => x.UserId == 1); // todo

            var list = query.ToList();

            return _mapper.Map<List<Model.Ratings>>(list);
        }

        public Model.Ratings GetById(int id)
        {
            var entity = _context.Ratings.Find(id);

            return _mapper.Map<Model.Ratings>(entity);
        }

        public Model.Ratings RateNotation(RatingsInsertRequest request)
        {
            int UserId = 1; // Todo

            Database.Ratings entity = _context.Ratings.Where(x => x.NotationId == request.NotationId && x.UserId == UserId).FirstOrDefault();
            if (entity != null)
            {
                entity.Rating = request.Rating;
            }
            else
            {
                entity = _mapper.Map<Database.Ratings>(request);
                entity.UserId = UserId;

                _context.Ratings.Add(entity);
            }
            _context.SaveChanges();
            return _mapper.Map<Model.Ratings>(entity);
        }
    }
}
