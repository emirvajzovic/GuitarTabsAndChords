using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuitarTabsAndChords.Model;
using GuitarTabsAndChords.Model.Requests;

namespace GuitarTabsAndChords.WebAPI.Services
{
    public interface IAlbumsService
    {
        List<Albums> Get(Model.Requests.AlbumsSearchRequest request);
        Albums GetById(int id);
        Albums Insert(AlbumsInsertRequest request);
        Albums Update(int id, AlbumsInsertRequest request);
    }
}
