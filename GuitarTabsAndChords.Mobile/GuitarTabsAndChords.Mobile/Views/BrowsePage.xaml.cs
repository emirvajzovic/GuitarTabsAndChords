﻿using GuitarTabsAndChords.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuitarTabsAndChords.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BrowsePage : ContentPage
    {
        private readonly BrowseViewModel VM;

        public BrowsePage()
        {
            InitializeComponent();
            BindingContext = VM = new BrowseViewModel();
        }
        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                Models.NotationBrowseListItem notation = e.Item as Models.NotationBrowseListItem;
                await Navigation.PushAsync(new NotationDetailsPage(notation.Id));
            }
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await VM.LoadItems();
        }

        private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            await VM.Search();
        }

        private void ListView_ItemTapped_1(object sender, ItemTappedEventArgs e)
        {
            if(e.Item != null)
            {
                Model.SearchResult item = e.Item as Model.SearchResult;
                switch(item.ResultTypeName)
                {
                    case "Song":
                        //Navigation.PushAsync(new SongPage(item.Id));
                        break;
                    case "Album":
                        //Navigation.PushAsync(new AlbumPage(item.Id));
                        break;
                    case "Artist":
                        //Navigation.PushAsync(new ArtistPage(item.Id));
                        break;
                    default:
                        break;
                }
            }
        }
    }
}