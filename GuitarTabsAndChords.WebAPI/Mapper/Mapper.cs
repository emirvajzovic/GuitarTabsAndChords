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
            CreateMap<Database.Artists, Model.Requests.ArtistsInsertRequest>().ReverseMap();
        }
    }
}
