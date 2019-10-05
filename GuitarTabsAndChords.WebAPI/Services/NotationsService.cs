﻿using AutoMapper;
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
    public class NotationsService : INotationsService
    {
        private readonly GuitarTabsContext _context;
        private readonly IMapper _mapper;

        public NotationsService(GuitarTabsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.Notations> Get(NotationsSearchRequest request)
        {
            var query = _context.Notations.AsQueryable();

            if (request?.AlbumId != 0)
                query = query.Where(x => x.Song.AlbumId == request.AlbumId);
            if (request?.ArtistId != 0)
                query = query.Where(x => x.Song.ArtistId == request.ArtistId);
            if (request?.GenreId != 0)
                query = query.Where(x => x.Song.GenreId == request.GenreId);
            if (request?.SongId != 0)
                query = query.Where(x => x.SongId == request.SongId);
            if (!string.IsNullOrWhiteSpace(request?.Tuning))
                query = query.Where(x => x.Tuning == request.Tuning);

            if (!string.IsNullOrWhiteSpace(request?.SearchTerm))
                query = query.Where(x => x.Song.Artist.Name.Contains(request.SearchTerm) || x.Song.Album.Name.Contains(request.SearchTerm) || x.Song.Name.Contains(request.SearchTerm) || x.User.Username.Contains(request.SearchTerm));

            if (request.Filter.HasValue)
            {
                if (request.Filter.Value == (int)ReviewStatus.FilterPendingApproved)
                    query = query.Where(x => x.Status == ReviewStatus.Pending || x.Status == ReviewStatus.Approved);
                else
                    query = query.Where(x => (int)x.Status == request.Filter.Value);
            }

            query = query
                .Include(x => x.Song.Album)
                .Include(x => x.Song.Artist)
                .Include(x => x.Song.Genre)
                .Include(x => x.User)
                .Include(x=>x.LastEditor);

            var list = query.ToList();

            return _mapper.Map<List<Model.Notations>>(list);
        }

        public Model.Notations GetById(int id)
        {
            var entity = _context.Notations.Where(x => x.Id == id)
                .Include(x => x.Song.Album)
                .Include(x => x.Song.Artist)
                .Include(x => x.Song.Genre)
                .Include(x => x.User)
                .Include(x => x.LastEditor)
                .FirstOrDefault();

            if(entity != null)
            {
                NotationViews view = new NotationViews
                {
                    NotationId = entity.Id,
                    Timestamp = DateTime.Now
                };
                _context.NotationViews.Add(view);
                _context.SaveChanges();
            }

            var notation = _mapper.Map<Model.Notations>(entity);

            IncludeNotationStats(notation);

            return notation;
        }

        private void IncludeNotationStats(Model.Notations entity)
        {
            entity.Rating = (int)Math.Round(_context.Ratings.Where(x => x.NotationId == entity.Id).Average(x => (double?)x.Rating) ?? 0);
            entity.Favorites = _context.Favorites.Count(x => x.NotationId == entity.Id);
            entity.Views = _context.NotationViews.Count(x => x.NotationId == entity.Id);
        }

        public Model.Notations Insert(NotationsInsertRequest request)
        {
            var entity = _mapper.Map<Database.Notations>(request);

            entity.Status = ReviewStatus.Approved;

            entity.LastEditted = entity.DateAdded = DateTime.Now;
            entity.LastEditorId = 1;
            entity.UserId = 1;

            _context.Notations.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Notations>(entity);
        }

        public Model.Notations Update(int id, NotationsInsertRequest request)
        {
            var entity = _context.Notations.Find(id);

            _context.Notations.Attach(entity);
            _context.Notations.Update(entity);

            entity.LastEditted = DateTime.Now;
            entity.LastEditorId = 1;

            if (request.Status == ReviewStatus.Rejected)
                entity.Status = ReviewStatus.Rejected;
            else
                _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<Model.Notations>(entity);
        }
    }
}