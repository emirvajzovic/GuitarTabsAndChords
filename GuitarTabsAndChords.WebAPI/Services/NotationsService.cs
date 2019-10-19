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
    public class NotationsService : INotationsService
    {
        private readonly GuitarTabsContext _context;
        private readonly IMapper _mapper;
        private readonly IUsersService _usersService;

        public NotationsService(GuitarTabsContext context, IMapper mapper, IUsersService usersService)
        {
            _context = context;
            _mapper = mapper;
            _usersService = usersService;
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
            if (request?.UserId != 0)
                query = query.Where(x => x.UserId == request.UserId);
            if (request?.Type != null)
                query = query.Where(x => x.Type == request.Type.Value);
            if (request?.Decade != 0)
                query = query.Where(x =>
                    (x.Song.Year != 0
                        ? (x.Song.Year >= request.Decade / 10 * 10 && x.Song.Year <= request.Decade / 10 * 10 + 9)
                        : (x.Song.Album.Year != 0
                                ? (x.Song.Album.Year >= request.Decade / 10 * 10 && x.Song.Album.Year <= request.Decade / 10 * 10 + 9)
                                : false
                        )
                    )
                );

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
                .Include(x => x.LastEditor);

            if (request?.ArtistId != 0)
            {
                query = query.OrderByDescending(x => _context.NotationViews.Where(nv => nv.NotationId == x.Id).Count());
            }
            else
            {
                if (request?.Sort != null)
                {
                    switch (request?.Sort)
                    {
                        case NotationSort.RECENTLY_ADDED:
                            query = query.OrderByDescending(x => x.DateAdded);
                            break;
                        case NotationSort.SONG_ASC:
                            query = query.OrderBy(x => x.Song.Name);
                            break;
                        case NotationSort.SONG_DESC:
                            query = query.OrderByDescending(x => x.Song.Name);
                            break;
                        case NotationSort.ARTIST_ASC:
                            query = query.OrderBy(x => x.Song.Artist.Name);
                            break;
                        case NotationSort.ARTIST_DESC:
                            query = query.OrderByDescending(x => x.Song.Artist.Name);
                            break;
                        case NotationSort.RATING:
                            query = query.OrderByDescending(notation => _context.Ratings
                                .Where(rating => rating.NotationId == notation.Id)
                                .Average(rating => (double?)rating.Rating) ?? 0);
                            break;
                        default:
                            break;
                    }
                }
            }

            var list = query.ToList();

            List<Model.Notations> notationList = _mapper.Map<List<Model.Notations>>(list);

            foreach (var entity in notationList)
            {
                entity.Rating = _context.Ratings.Where(x => x.NotationId == entity.Id).Average(x => (double?)x.Rating) ?? 0;
                entity.Views = _context.NotationViews
                    .Where(x => x.Timestamp >= DateTime.Now.AddDays(-7))
                    .Count(x => x.NotationId == entity.Id);
            }

            return notationList;
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

            if (entity != null)
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

            if (_usersService.GetCurrentUser().Role.Name == "Administrator")
                entity.Status = ReviewStatus.Approved;
            else
                entity.Status = ReviewStatus.Pending;

            entity.LastEditted = entity.DateAdded = DateTime.Now;
            entity.LastEditorId = _usersService.GetCurrentUser().Id;
            entity.UserId = _usersService.GetCurrentUser().Id;

            _context.Notations.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Notations>(entity);
        }

        public Model.Notations Update(int id, NotationsInsertRequest request)
        {
            var entity = _context.Notations.Find(id);

            _context.Notations.Attach(entity);
            _context.Notations.Update(entity);

            if (request.Status == ReviewStatus.Rejected)
                entity.Status = ReviewStatus.Rejected;
            else
                _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<Model.Notations>(entity);
        }

        public List<Model.Notations> GetThisWeekTop5()
        {
            var query = _context.Notations.AsQueryable();

            query = query.Where(x => x.Status == ReviewStatus.Approved);

            query = query
                .Include(x => x.Song.Artist)
                .Include(x => x.Song.Album)
                .Include(x => x.Song.Genre)
                .Include(x => x.User);

            query = query.OrderByDescending(x => _context
                    .NotationViews
                    .Where(views => views.Timestamp >= DateTime.Now.AddDays(-7))
                    .Count(views => views.NotationId == x.Id)
                ).Take(5);


            var list = query.ToList();

            List<Model.Notations> notationList = _mapper.Map<List<Model.Notations>>(list);

            foreach (var entity in notationList)
            {
                entity.Rating = _context.Ratings.Where(x => x.NotationId == entity.Id).Average(x => (double?)x.Rating) ?? 0;
                entity.Views = _context.NotationViews
                    .Where(x => x.Timestamp >= DateTime.Now.AddDays(-7))
                    .Count(x => x.NotationId == entity.Id);
            }

            return notationList;
        }

        public List<Model.Notations> GetTop100()
        {
            var query = _context.Notations.AsQueryable();

            query = query.Where(x => x.Status == ReviewStatus.Approved);

            query = query
                .Include(x => x.Song.Artist)
                .Include(x => x.Song.Genre)
                .Include(x => x.User);

            query = query.OrderByDescending(x => _context
                .Ratings
                .Where(views => views.NotationId == x.Id)
                .Average(avg => (double?)avg.Rating) ?? 0
            ).Take(100);

            var list = query.ToList();

            List<Model.Notations> notationList = _mapper.Map<List<Model.Notations>>(list);

            foreach (var entity in notationList)
            {
                entity.Rating = _context.Ratings.Where(x => x.NotationId == entity.Id).Average(x => (double?)x.Rating) ?? 0;
                entity.Views = _context.NotationViews
                    .Count(x => x.NotationId == entity.Id);
            }

            return notationList;
        }


        public List<Model.Notations> GetPopularNotations(NotationsSearchRequest request)
        {
            var query = _context.Notations.AsQueryable();

            query = query.Where(x => x.Status == ReviewStatus.Approved);
            if (request.Type != null)
                query = query.Where(x => x.Type == request.Type);

            query = query
                .Include(x => x.Song.Album)
                .Include(x => x.Song.Artist)
                .Include(x => x.Song.Genre)
                .Include(x => x.User);

            query = query.OrderByDescending(x => _context
                    .NotationViews
                    .Where(views => views.Timestamp >= DateTime.Now.AddDays(-14))
                    .Count(views => views.NotationId == x.Id)
                ).Take(10);


            var list = query.ToList();

            return _mapper.Map<List<Model.Notations>>(list);
        }

        public List<int> GetDecades()
        {
            return _context.Notations
                .Where(x => x.Song.Year >= 1930 || x.Song.Album.Year >= 1930)
                .Where(x => x.Status == ReviewStatus.Approved)
                .Select(x => (x.Song.Year != 0 ? x.Song.Year / 10 * 10 : x.Song.Album.Year / 10 * 10))
                .Distinct()
                .OrderByDescending(x => x)
                .ToList();
        }
    }
}
