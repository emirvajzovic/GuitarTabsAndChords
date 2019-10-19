using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuitarTabsAndChords.Model;
using GuitarTabsAndChords.Model.Requests;

namespace GuitarTabsAndChords.WebAPI.Services
{
    public interface INotationCorrectionsService
    {
        List<NotationCorrections> Get();
        NotationCorrections GetById(int id);
        NotationCorrections Insert(NotationCorrectionsInsertRequest request);
        NotationCorrections Update(int id, NotationCorrectionsUpdateRequest request);
    }
}
