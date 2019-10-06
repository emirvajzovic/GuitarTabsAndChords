using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuitarTabsAndChords.Model;
using GuitarTabsAndChords.Model.Requests;

namespace GuitarTabsAndChords.WebAPI.Services
{
    public interface INotationsService
    {
        List<Notations> Get(Model.Requests.NotationsSearchRequest request);
        Notations GetById(int id);
        Notations Insert(NotationsInsertRequest request);
        Notations Update(int id, NotationsInsertRequest request);
        List<Notations> GetThisWeekTop5();
        List<Notations> GetTop100();
    }
}
