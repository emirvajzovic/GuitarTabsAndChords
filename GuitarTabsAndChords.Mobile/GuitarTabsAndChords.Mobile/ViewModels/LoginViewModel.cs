using GuitarTabsAndChords.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GuitarTabsAndChords.Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("Users");

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await Login());
            Title = "Login";
        }
        string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public ICommand LoginCommand { get; set; }

        async Task Login()
        {
            IsBusy = true;
            APIService.Username = Username;
            APIService.Password = Password;

            try
            {
                APIService.CurrentUser = await _service.Get<Model.Users>(null, "MyProfile");

#pragma warning disable CS0612 // Type or member is obsolete
                Application.Current.MainPage = new MainPage();
#pragma warning restore CS0612 // Type or member is obsolete
            }
            catch (Exception)
            {

            }
        }
    }
}
