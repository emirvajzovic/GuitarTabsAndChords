using GuitarTabsAndChords.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GuitarTabsAndChords.Mobile.ViewModels
{
    public class EditProfilePageViewModel : BaseViewModel
    {
        private readonly APIService _serviceUsers = new APIService("Users");

        private int _userId;

        private Model.Requests.UsersUpdateRequest _user;

        public Model.Requests.UsersUpdateRequest User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        public ICommand SaveProfileCommand { get; set; }


        public EditProfilePageViewModel()
        {
            SaveProfileCommand = new Command(async () => await SaveProfile());
        }

        public async Task Init()
        {
            _userId = (await APIService.GetCurrentUser()).Id;
            await LoadUser();

        }

        private async Task LoadUser()
        {
            if (User == null)
            {
                User = await _serviceUsers.Get<Model.Requests.UsersUpdateRequest>(null, "MyProfile");

                if (User.ProfilePicture.Length == 0)
                {
                    User.ProfilePicture = File.ReadAllBytes("logo.png");
                }
                Title = "Edit Profile - " + User.Username;
            }

        }

        private async Task SaveProfile()
        {
            var entity = await _serviceUsers.Update<Model.Users>((await APIService.GetCurrentUser()).Id, User);
            if (entity != null)
            {
                APIService.Username = User.Username;
                if (!string.IsNullOrWhiteSpace(User.Password))
                {
                    APIService.Password = User.Password;
                }

                await SecureStorage.SetAsync("username", APIService.Username);
                await SecureStorage.SetAsync("password", APIService.Password);

                await Application.Current.MainPage.DisplayAlert("Success", "The profile was successfully saved.", "OK");
            }
        }



    }
}
