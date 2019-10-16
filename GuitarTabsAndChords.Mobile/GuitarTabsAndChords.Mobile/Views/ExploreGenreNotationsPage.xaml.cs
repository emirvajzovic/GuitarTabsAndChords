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
    public partial class ExploreGenreNotationsPage : ContentPage
    {
        private readonly ExploreGenreNotationsViewModel VM;

        public ExploreGenreNotationsPage(int GenreId)
        {
            InitializeComponent();
            BindingContext = VM = new ExploreGenreNotationsViewModel(GenreId);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await VM.LoadGenre();
            await VM.LoadNotations();
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
    }
}