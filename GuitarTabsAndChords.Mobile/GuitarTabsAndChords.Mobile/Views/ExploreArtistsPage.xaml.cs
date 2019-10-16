using GuitarTabsAndChords.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuitarTabsAndChords.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuitarTabsAndChords.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExploreArtistsPage : ContentPage
    {
        private readonly ExploreArtistsViewModel VM;

        public ExploreArtistsPage()
        {
            InitializeComponent();
            BindingContext = VM = new ExploreArtistsViewModel();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                Artists artist = e.Item as Artists;
                await Navigation.PushAsync(new ArtistPage(artist.Id));
            }
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await VM.Init();
        }


    }
}