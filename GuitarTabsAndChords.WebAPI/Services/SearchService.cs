using AutoMapper;
using GuitarTabsAndChords.Model;
using GuitarTabsAndChords.Model.Requests;
using GuitarTabsAndChords.WebAPI.Database;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarTabsAndChords.WebAPI.Services
{
    public class SearchService: ISearchService
    {
        private readonly GuitarTabsContext _context;
        private readonly IMapper _mapper;

        public SearchService(GuitarTabsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<SearchResult> Get(SearchRequest request)
        {
            var list = new List<SearchResult>();

            var songs = _context.Songs
                .Where(x=> x.Status == ReviewStatus.Approved)
                .Where(x => x.Name.Contains(request.SearchString))
                .Select(x => new SearchResult
            {
                Id = x.Id,
                ResultText = x.Name,
                ResultType = typeof(Model.Songs)
            });
            if (songs != null)
                list.AddRange(songs);

            var artists = _context.Artists
                .Where(x=> x.Status == ReviewStatus.Approved)
                .Where(x => x.Name.Contains(request.SearchString))
                .Select(x => new SearchResult
            {
                Id = x.Id,
                ResultText = x.Name,
                ResultType = typeof(Model.Artists)
            });
            if (artists != null)
                list.AddRange(artists);

            var albums = _context
                .Albums
                .Where(x=> x.Status == ReviewStatus.Approved)
                .Where(x => x.Name.Contains(request.SearchString))
                .Select(x => new SearchResult
            {
                Id = x.Id,
                ResultText = x.Name,
                ResultType = typeof(Model.Albums)
            });
            if (albums != null)
                list.AddRange(albums);

            return list;
        }
    }
}
