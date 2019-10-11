using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuitarTabsAndChords.Model;
using GuitarTabsAndChords.Model.Requests;

namespace GuitarTabsAndChords.WebAPI.Services
{
    public interface IUsersService
    {
        List<Model.Users> Get(Model.Requests.UsersSearchRequest request);
        Model.Users Insert(Model.Requests.UsersInsertRequest request);
        Model.Users Update(int id, Model.Requests.UsersUpdateRequest request);
        Model.Users GetById(int id);
        Users InsertAdmin(UsersInsertRequest request);
        Model.Users MyProfile();
        Model.Users Authenticate(string username, string pass);

        Model.Users GetCurrentUser();
        void SetCurrentUser(Model.Users user);
    }
}
