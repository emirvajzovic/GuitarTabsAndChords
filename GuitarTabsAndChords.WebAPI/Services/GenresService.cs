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
    public class GenresService : IGenresService
    {
        private readonly GuitarTabsContext _context;
        private readonly IMapper _mapper;

        public GenresService(GuitarTabsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.Genres> Get(GenresSearchRequest request)
        {
            var query = _context.Genres.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Name))
                query = query.Where(x => x.Name.Contains(request.Name));

            if (request.Filter.HasValue)
            {
                if (request.Filter.Value == (int)ReviewStatus.FilterPendingApproved)
                    query = query.Where(x => x.Status == ReviewStatus.Pending || x.Status == ReviewStatus.Approved);
                else
                    query = query.Where(x => (int)x.Status == request.Filter.Value);
            }

            var list = query.ToList();

            return _mapper.Map<List<Model.Genres>>(list);
        }

        public Model.Genres GetById(int id)
        {
            var entity = _context.Genres.Find(id);

            return _mapper.Map<Model.Genres>(entity);
        }

        public Model.Genres Insert(GenresInsertRequest request)
        {
            var entity = _mapper.Map<Database.Genres>(request);

            entity.Status = ReviewStatus.Approved;

            _context.Genres.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Genres>(entity);
        }

        public Model.Genres Update(int id, GenresInsertRequest request)
        {
            var entity = _context.Genres.Find(id);

            _context.Genres.Attach(entity);
            _context.Genres.Update(entity);

            if (request.Status == ReviewStatus.Rejected)
                entity.Status = ReviewStatus.Rejected;
            else
                _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<Model.Genres>(entity);
        }
    }
}
