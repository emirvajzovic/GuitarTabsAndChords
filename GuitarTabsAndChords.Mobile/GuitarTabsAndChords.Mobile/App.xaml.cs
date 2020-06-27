using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GuitarTabsAndChords.Mobile.Services;
using GuitarTabsAndChords.Mobile.Views;
using Xamarin.Essentials;

namespace GuitarTabsAndChords.Mobile
{
    public partial class App : Application
    {
        private readonly APIService _service = new APIService("Users");

        public App()
        {
            InitializeComponent();

        }

        protected override async void OnStart()
        {

#pragma warning disable CS0612 // Type or member is obsolete
            try
            {
                string username = await SecureStorage.GetAsync("username");
                string password = await SecureStorage.GetAsync("password");

                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    APIService.Username = username;
                    APIService.Password = password;

                    if (Connectivity.NetworkAccess >= NetworkAccess.Local)
                    {
                        try
                        {
                            APIService.CurrentUser = await _service.Get<Model.Users>(null, "MyProfile");

                            if ((await APIService.GetCurrentUser()).Role.Name == "User")
                            {
                                Current.MainPage = new MainPage();
                                return;
                            }

                            await Current.MainPage.DisplayAlert("Error", "Error logging in.", "OK");
                        }
                        catch (Exception)
                        {
                            await Current.MainPage.DisplayAlert("Error", "Session has expired. Please log in again.", "OK");
                        }
                    }
                    else
                    {
                        Current.MainPage = new MainPage();
                        return;
                    }
                }

            }
            catch (Exception)
            {
                // Possible that device doesn't support secure storage on device.
            }

            Current.MainPage = new LoginPage();

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
