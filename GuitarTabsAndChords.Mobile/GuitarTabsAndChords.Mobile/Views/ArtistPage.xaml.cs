using GuitarTabsAndChords.Mobile.ViewModels;
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
    public partial class ArtistPage : ContentPage
    {
        private readonly ArtistPageViewModel VM;

        public ArtistPage(int SongId)
        {
            InitializeComponent();
            BindingContext = VM = new ArtistPageViewModel(SongId);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await VM.Init();
        }


        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                Models.NotationBrowseListItem notation = e.Item as Models.NotationBrowseListItem;
                await Navigation.PushAsync(new NotationDetailsPage(notation.Id));
            }
        }

        private void AlbumCollectionViewItem_Tapped(object sender, EventArgs e)
        {
            var element = sender as StackLayout;
            var context = element.BindingContext as Model.Albums;

            if (context != null)
            {
                Navigation.PushAsync(new AlbumPage(context.Id));
            }
        }
    }
}