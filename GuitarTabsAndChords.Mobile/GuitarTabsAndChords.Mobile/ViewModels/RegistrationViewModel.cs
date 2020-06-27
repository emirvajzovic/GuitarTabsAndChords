using GuitarTabsAndChords.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GuitarTabsAndChords.Mobile.ViewModels
{
    public class RegistrationViewModel : BaseViewModel
    {
        private readonly APIService _serviceUsers = new APIService("Users");

        public RegistrationViewModel()
        {
            RegistrationCommand = new Command(async () => await Register());
            Title = "Registration";
            _user = new Model.Requests.UsersUpdateRequest();
        }

        private bool _isButtonEnabled = true;
        public bool IsButtonEnabled
        {
            get { return _isButtonEnabled; }
            set { SetProperty(ref _isButtonEnabled, value); }
        }

        private Model.Requests.UsersUpdateRequest _user;
        public Model.Requests.UsersUpdateRequest User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }


        public ICommand RegistrationCommand { get; set; }

        async Task Register()
        {
            if (Connectivity.NetworkAccess < NetworkAccess.Local)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "You need to be connected to the Internet.", "OK");
                return;
            }

            IsButtonEnabled = false;

            try
            {
                var entity = await _serviceUsers.Insert<Model.Users>(User, "Register");
                if (entity == null)
                    throw new Exception();

                APIService.Username = User.Username;
                APIService.Password = User.Password;
                APIService.CurrentUser = await _serviceUsers.Get<Model.Users>(null, "MyProfile");

                await SecureStorage.SetAsync("username", APIService.Username);
                await SecureStorage.SetAsync("password", APIService.Password);

#pragma warning disable CS0612 // Type or member is obsolete
                Application.Current.MainPage = new MainPage();
#pragma warning restore CS0612 // Type or member is obsolete
            }
            catch (Exception)
            {

            }
            finally
            {
                IsButtonEnabled = true;
            }
        }
    }
}
