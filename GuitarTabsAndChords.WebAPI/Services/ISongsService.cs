using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuitarTabsAndChords.Model;
using GuitarTabsAndChords.Model.Requests;

namespace GuitarTabsAndChords.WebAPI.Services
{
    public interface ISongsService
    {
        List<Songs> Get(Model.Requests.SongsSearchRequest request);
        Songs GetById(int id);
        Songs Insert(SongsInsertRequest request);
        Songs Update(int id, SongsInsertRequest request);
    }
}
