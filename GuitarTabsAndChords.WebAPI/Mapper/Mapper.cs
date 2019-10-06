using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarTabsAndChords.WebAPI.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Database.Artists, Model.Artists>();
            CreateMap<Database.Albums, Model.Albums>();
            CreateMap<Database.Favorites, Model.Favorites>();
            CreateMap<Database.Genres, Model.Genres>();
            CreateMap<Database.Notations, Model.Notations>();
            CreateMap<Database.Ratings, Model.Ratings>();
            CreateMap<Database.Roles, Model.Roles>();
            CreateMap<Database.Songs, Model.Songs>();
            CreateMap<Database.NotationCorrections, Model.NotationCorrections>();
            CreateMap<Database.Users, Model.Users>();

            CreateMap<Database.Artists, Model.Requests.ArtistsInsertRequest>().ReverseMap();
            CreateMap<Database.Albums, Model.Requests.AlbumsInsertRequest>().ReverseMap();
            CreateMap<Database.Songs, Model.Requests.SongsInsertRequest>().ReverseMap();
            CreateMap<Database.Genres, Model.Requests.GenresInsertRequest>().ReverseMap();
            CreateMap<Database.Users, Model.Requests.UsersInsertRequest>().ReverseMap();
            CreateMap<Database.Users, Model.Requests.UsersUpdateRequest>().ReverseMap();
            CreateMap<Database.Notations, Model.Requests.NotationsInsertRequest>().ReverseMap();
            CreateMap<Database.Ratings, Model.Requests.RatingsInsertRequest>().ReverseMap();
            CreateMap<Database.Favorites, Model.Requests.FavoritesInsertRequest>().ReverseMap();
        }
    }
}
