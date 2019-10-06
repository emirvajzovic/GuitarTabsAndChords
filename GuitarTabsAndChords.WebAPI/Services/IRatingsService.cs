using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuitarTabsAndChords.Model;
using GuitarTabsAndChords.Model.Requests;

namespace GuitarTabsAndChords.WebAPI.Services
{
    public interface IRatingsService
    {
        List<Ratings> Get(Model.Requests.RatingsSearchRequest request);
        Ratings GetById(int id);
        Ratings RateNotation(RatingsInsertRequest request);
    }
}
