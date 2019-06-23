using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuitarTabsAndChords.Model;
using GuitarTabsAndChords.Model.Requests;

namespace GuitarTabsAndChords.WebAPI.Services
{
    public interface IArtistsService
    {
        List<Artists> Get(Model.Requests.ArtistsSearchRequest request);
        Artists GetById(int id);
        Artists Insert(ArtistsInsertRequest request);
        Artists Update(int id, ArtistsInsertRequest request);
    }
}
