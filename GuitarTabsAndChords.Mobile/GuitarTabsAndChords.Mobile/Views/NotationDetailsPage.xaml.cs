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
    public partial class NotationDetailsPage : ContentPage
    {
        private NotationDetailsViewModel VM;

        public NotationDetailsPage(int NotationId)
        {
            InitializeComponent();
            BindingContext = VM = new NotationDetailsViewModel(NotationId, FavoriteToolbarItem, Navigation);
        }

        private void FavoriteToolbarItem_Clicked(object sender, EventArgs e)
        {
            VM.ToggleFavoriteNotation();
        }

        private void SongLabel_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SongPage(VM.Notation.SongId));
        }

        private void ArtistLabel_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ArtistPage(VM.Notation.Song.ArtistId));
        }

        private void UserLabel_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProfilePage(VM.Notation.UserId));
        }

        private void LastEditLabel_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProfilePage(VM.Notation.LastEditorId));
        }
    }
}