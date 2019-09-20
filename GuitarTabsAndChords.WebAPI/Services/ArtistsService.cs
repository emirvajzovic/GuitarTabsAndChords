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
    public class ArtistsService: IArtistsService
    {
        private readonly GuitarTabsContext _context;
        private readonly IMapper _mapper;

        public ArtistsService(GuitarTabsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.Artists> Get(ArtistsSearchRequest request)
        {
            var query = _context.Artists.AsQueryable();

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

            return _mapper.Map<List<Model.Artists>>(list);
        }

        public Model.Artists GetById(int id)
        {
            var entity = _context.Artists.Find(id);

            return _mapper.Map<Model.Artists>(entity);
        }

        public Model.Artists Insert(ArtistsInsertRequest request)
        {
            var entity = _mapper.Map<Database.Artists>(request);

            entity.Status = ReviewStatus.Approved;

            _context.Artists.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Artists>(entity);
        }

        public Model.Artists Update(int id, ArtistsInsertRequest request)
        {
            var entity = _context.Artists.Find(id);

            _context.Artists.Attach(entity);
            _context.Artists.Update(entity);

            if (request.Status == ReviewStatus.Rejected)
                entity.Status = ReviewStatus.Rejected;
            else
                _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<Model.Artists>(entity);
        }
    }
}
