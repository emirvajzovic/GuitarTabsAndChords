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
    public partial class FavoritesPage : ContentPage
    {
        private readonly FavoritesViewModel VM;

        public FavoritesPage()
        {
            InitializeComponent();
            BindingContext = VM = new FavoritesViewModel();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if(e.Item != null)
            {
                Models.NotationFavoritesListItem favorite = e.Item as Models.NotationFavoritesListItem;
                await Navigation.PushAsync(new NotationDetailsPage(favorite.NotationId));
            }
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            VM.HasConnectivity = (Connectivity.NetworkAccess >= NetworkAccess.Local);
            VM.NoConnectivity = !VM.HasConnectivity;

            await VM.LoadItems();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}