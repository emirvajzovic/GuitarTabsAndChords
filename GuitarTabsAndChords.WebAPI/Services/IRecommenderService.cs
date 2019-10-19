using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarTabsAndChords.WebAPI.Services
{
    public interface IRecommenderService
    {
        List<Model.Notations> GetRecommendedNotations();
    }
}
