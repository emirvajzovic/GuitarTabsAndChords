using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuitarTabsAndChords.Model;
using GuitarTabsAndChords.Model.Requests;

namespace GuitarTabsAndChords.WebAPI.Services
{
    public interface IGenresService
    {
        List<Genres> Get(Model.Requests.GenresSearchRequest request);
        Genres GetById(int id);
        Genres Insert(GenresInsertRequest request);
        Genres Update(int id, GenresInsertRequest request);
    }
}
