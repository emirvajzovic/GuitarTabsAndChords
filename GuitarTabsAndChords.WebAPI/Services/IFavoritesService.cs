using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuitarTabsAndChords.Model;
using GuitarTabsAndChords.Model.Requests;

namespace GuitarTabsAndChords.WebAPI.Services
{
    public interface IFavoritesService
    {
        List<Favorites> Get(Model.Requests.FavoritesSearchRequest request);
        Favorites GetById(int id);
        bool Delete(int id);
        Favorites Insert(FavoritesInsertRequest request);
    }
}
