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
    public class SongsService: ISongsService
    {
        private readonly GuitarTabsContext _context;
        private readonly IMapper _mapper;

        public SongsService(GuitarTabsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.Songs> Get(SongsSearchRequest request)
        {
            var query = _context.Songs.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Name))
                query = query.Where(x => x.Name.Contains(request.Name));
            if (request?.Year != 0)
                query = query.Where(x => x.Year == request.Year);
            if (request?.AlbumId != 0)
                query = query.Where(x => x.AlbumId == request.AlbumId);
            if (request?.ArtistId != 0)
                query = query.Where(x => x.ArtistId == request.ArtistId);
            if (request?.GenreId != 0)
                query = query.Where(x => x.GenreId == request.GenreId);

            if (!string.IsNullOrWhiteSpace(request?.SearchTerm))
                query = query.Where(x => x.Name.Contains(request.SearchTerm) || x.Year.ToString() == request.SearchTerm || x.Artist.Name.Contains(request.SearchTerm) || x.Album.Name.Contains(request.SearchTerm));

            if (request.Filter.HasValue)
            {
                if (request.Filter.Value == (int)ReviewStatus.FilterPendingApproved)
                    query = query.Where(x => x.Status == ReviewStatus.Pending || x.Status == ReviewStatus.Approved);
                else
                    query = query.Where(x => (int)x.Status == request.Filter.Value);
            }

            query = query
                .Include(x => x.Album)
                .Include(x => x.Artist)
                .Include(x => x.Genre);

            var list = query.ToList();

            return _mapper.Map<List<Model.Songs>>(list);
        }

        public Model.Songs GetById(int id)
        {
            var entity = _context.Songs.Where(x=>x.Id == id)
                .Include(x=>x.Genre)
                .Include(x=>x.Album)
                .Include(x=>x.Artist)
                .FirstOrDefault();

            return _mapper.Map<Model.Songs>(entity);
        }

        public Model.Songs Insert(SongsInsertRequest request)
        {
            var entity = _mapper.Map<Database.Songs>(request);

            entity.Status = ReviewStatus.Approved;

            _context.Songs.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Songs>(entity);
        }

        public Model.Songs Update(int id, SongsInsertRequest request)
        {
            var entity = _context.Songs.Find(id);

            _context.Songs.Attach(entity);
            _context.Songs.Update(entity);

            if (request.Status == ReviewStatus.Rejected)
                entity.Status = ReviewStatus.Rejected;
            else
                _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<Model.Songs>(entity);
        }
    }
}
