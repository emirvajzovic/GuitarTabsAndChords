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
    public class NotationCorrectionsService : INotationCorrectionsService
    {
        private readonly GuitarTabsContext _context;
        private readonly IMapper _mapper;
        private readonly IUsersService _usersService;

        public NotationCorrectionsService(GuitarTabsContext context, IMapper mapper, IUsersService usersService)
        {
            _context = context;
            _mapper = mapper;
            _usersService = usersService;
        }

        public List<Model.NotationCorrections> Get()
        {
            var query = _context.NotationCorrections.AsQueryable();

            query = query.Where(x => x.Status == ReviewStatus.Pending);

            query = query
                .Include(x => x.Notation.Song.Album)
                .Include(x => x.Notation.Song.Artist)
                .Include(x => x.Notation.Song.Genre)
                .Include(x => x.Notation.User)
                .Include(x => x.Notation.LastEditor);

            query = query.OrderBy(x => x.DateSubmitted);

            var list = query.ToList();

            return _mapper.Map<List<Model.NotationCorrections>>(list);
        }

        public Model.NotationCorrections GetById(int id)
        {
            var entity = _context.NotationCorrections.Where(x => x.Id == id)
                .Include(x => x.Notation.Song.Album)
                .Include(x => x.Notation.Song.Artist)
                .Include(x => x.Notation.Song.Genre)
                .Include(x => x.Notation.User)
                .Include(x => x.Notation.LastEditor)
                .FirstOrDefault();

            return _mapper.Map<Model.NotationCorrections>(entity);
        }

        public Model.NotationCorrections Insert(NotationCorrectionsInsertRequest request)
        {
            var entity = _mapper.Map<Database.NotationCorrections>(request);

            entity.Status = ReviewStatus.Pending;

            entity.UserId = _usersService.GetCurrentUser().Id;
            entity.DateSubmitted = DateTime.Now;

            _context.NotationCorrections.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.NotationCorrections>(entity);
        }

        public Model.NotationCorrections Update(int id, NotationCorrectionsUpdateRequest request)
        {
            var entity = _context.NotationCorrections.Find(id);

            _context.NotationCorrections.Attach(entity);
            _context.NotationCorrections.Update(entity);

            if (request.Approved)
            {
                entity.Status = ReviewStatus.Approved;

                var notation = _context.Notations.Find(entity.NotationId);
                notation.NotationContent = entity.NotationContent;
                notation.LastEditorId = entity.UserId;
                notation.LastEditted = DateTime.Now;

            }
            else
                entity.Status = ReviewStatus.Rejected;

            _context.SaveChanges();

            return _mapper.Map<Model.NotationCorrections>(entity);
        }

    }
}
