using GuitarTabsAndChords.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GuitarTabsAndChords.Mobile.ViewModels
{
    public class EditProfilePageViewModel : BaseViewModel
    {
        private readonly APIService _serviceUsers = new APIService("Users");

        private readonly int _userId;

        private Model.Requests.UsersUpdateRequest _user;

        public Model.Requests.UsersUpdateRequest User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        public ICommand SaveProfileCommand { get; set; }


        public EditProfilePageViewModel()
        {
            _userId = APIService.CurrentUser.Id;
            SaveProfileCommand = new Command(async () => await SaveProfile());
        }

        public async Task Init()
        {
            await LoadUser();

        }

        private async Task LoadUser()
        {
            if(User == null)
            {
                User = await _serviceUsers.Get<Model.Requests.UsersUpdateRequest>(null, "MyProfile");
                Title = "Edit Profile - " + User.Username;
            }
            
        }

        private async Task SaveProfile()
        {
            var entity = await _serviceUsers.Update<Model.Users>(APIService.CurrentUser.Id, User);
            if (entity != null)
            {
                APIService.Username = User.Username;
                if (!string.IsNullOrWhiteSpace(User.Password))
                {
                    APIService.Password = User.Password;
                }
                await Application.Current.MainPage.DisplayAlert("Success", "The profile was successfully saved.", "OK");
            }
        }



    }
}
