using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GuitarTabsAndChords.Mobile.Services;
using GuitarTabsAndChords.Mobile.Views;

namespace GuitarTabsAndChords.Mobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
#pragma warning disable CS0612 // Type or member is obsolete
            MainPage = new LoginPage();
#pragma warning restore CS0612 // Type or member is obsolete
        }

        protected override void OnStart()
        {
            // Handle when your app starts
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
