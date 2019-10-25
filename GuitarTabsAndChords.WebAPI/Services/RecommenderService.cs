using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GuitarTabsAndChords.WebAPI.Database;
using Microsoft.EntityFrameworkCore;

namespace GuitarTabsAndChords.WebAPI.Services
{
    public class RecommenderService : IRecommenderService
    {
        private readonly GuitarTabsContext _context;

        private readonly IMapper _mapper;
        private readonly IUsersService _usersService;
        private readonly INotationsService _notationService;
        private readonly int PositiveRating = 3;
        private readonly int ResultsLimit = 5;

        public RecommenderService(GuitarTabsContext context, IMapper mapper, IUsersService usersService, INotationsService notationService)
        {
            _context = context;
            _mapper = mapper;
            _usersService = usersService;
            _notationService = notationService;
        }
        public List<Model.Notations> GetRecommendedNotations()
        {
            int UserId = _usersService.GetCurrentUser().Id;
            if (UserId != 0)
            {
                List<Ratings> ListOfRatings = _context.Ratings.Where(x => x.UserId == UserId)
                    .Include(m => m.Notation.Song.Album)
                    .ToList();

                List<Ratings> ListOfPositiveRatings = ListOfRatings
                    .Where(x => x.Rating >= PositiveRating)
                    .ToList();

                if (ListOfPositiveRatings.Count() > 0)
                {
                    List<Genres> uniqueGenres = new List<Genres>();
                    foreach (var Rating in ListOfPositiveRatings)
                    {
                        var albumGenres = _context.Songs.Where(m => m.AlbumId == Rating.Notation.Song.AlbumId)
                            .Select(g => g.Genre)
                            .ToList();

                        foreach (var Genre in albumGenres)
                        {
                            bool add = true;
                            for (int i = 0; i < uniqueGenres.Count; i++)
                            {
                                if (Genre.Id == uniqueGenres[i].Id)
                                {
                                    add = false;
                                }
                            }

                            if (add)
                            {
                                uniqueGenres.Add(Genre);
                            }
                        }
                    }

                    List<Notations> ListOfRecommendedNotations = new List<Notations>();
                    foreach (var Genre in uniqueGenres)
                    {
                        var NotationsInGenre = _context.Notations
                            .Where(x => x.Status == Model.ReviewStatus.Approved)
                            .Where(n => n.Song.Genre.Name == Genre.Name)
                            .Include(m => m.Song.Album)
                            .Include(m => m.Song.Artist)
                            .Include(m => m.LastEditor)
                            .Include(m => m.User)
                            .ToList();

                        foreach (var Notation in NotationsInGenre)
                        {
                            bool add = true;
                            for (int i = 0; i < ListOfRecommendedNotations.Count; i++)
                            {
                                if (Notation.Id == ListOfRecommendedNotations[i].Id)
                                {
                                    add = false;
                                }
                            }

                            foreach (var Rating in ListOfRatings)
                            {
                                if (Notation.Id == Rating.NotationId)
                                {
                                    add = false;
                                }
                            }

                            if (add)
                            {
                                ListOfRecommendedNotations.Add(Notation);
                            }
                        }
                    }

                    ListOfRecommendedNotations = ListOfRecommendedNotations.OrderBy(media => Guid.NewGuid()).Take(ResultsLimit).ToList();

                    if (ListOfRecommendedNotations.Count == 0)
                    {
                        return _notationService.GetThisWeekTop5();
                    }

                    var list1 = _mapper.Map<List<Model.Notations>>(ListOfRecommendedNotations);

                    foreach (var entity in list1)
                    {
                        entity.Rating = _context.Ratings.Where(x => x.NotationId == entity.Id).Average(x => (double?)x.Rating) ?? 0;
                        entity.Views = _context.NotationViews
                            .Count(x => x.NotationId == entity.Id);
                    }

                    return list1;
                }
            }

            var ListOfAllNotations = _context.Notations
                                        .Where(x => x.Status == Model.ReviewStatus.Approved)
                                        .Include(m => m.Song).ThenInclude(x=>x.Genre)
                                        .Include(m => m.Song).ThenInclude(x => x.Artist)
                                        .Include(m => m.Song).ThenInclude(x=>x.Album)
                                        .Include(m => m.LastEditor)
                                        .Include(m => m.User)
                                        .OrderBy(media => Guid.NewGuid()).Take(ResultsLimit).ToList();

            var list2 = _mapper.Map<List<Model.Notations>>(ListOfAllNotations);

            foreach (var entity in list2)
            {
                entity.Rating = _context.Ratings.Where(x => x.NotationId == entity.Id).Average(x => (double?)x.Rating) ?? 0;
                entity.Views = _context.NotationViews
                    .Count(x => x.NotationId == entity.Id);
            }

            return list2;

        }

    }
}
