﻿using GuitarTabsAndChords.Mobile.Services;
using GuitarTabsAndChords.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuitarTabsAndChords.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private HomeViewModel VM;

        public HomePage()
        {
            InitializeComponent();
            BindingContext = VM = new HomeViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            VM.HasConnectivity = (Connectivity.NetworkAccess >= NetworkAccess.Local);
            VM.NoConnectivity = !VM.HasConnectivity;

            await VM.LoadItems();

            VM.PopulateMenuList();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var element = sender as StackLayout;
            var context = element.BindingContext as Model.Notations;

            await Navigation.PushAsync(new NotationDetailsPage(context.Id));
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if(e.Item != null)
            {
                Models.MenuItem menuItem = e.Item as Models.MenuItem;
                if(menuItem.Page == null)
                {
                    SecureStorage.Remove("username");
                    SecureStorage.Remove("password");
                    NotationStorageHelper.RemoveAll();
                    Application.Current.MainPage = new LoginPage();
                }
                else
                {
                    Page instance = (Page)Activator.CreateInstance(menuItem.Page);
                    await Navigation.PushAsync(instance);
                }
            }
        }
    }
}