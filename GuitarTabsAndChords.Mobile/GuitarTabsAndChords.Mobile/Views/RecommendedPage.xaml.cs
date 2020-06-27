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
    public partial class RecommendedPage : ContentPage
    {
        private readonly RecommendedViewModel VM;

        public RecommendedPage()
        {
            InitializeComponent();
            BindingContext = VM = new RecommendedViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            VM.HasConnectivity = (Connectivity.NetworkAccess >= NetworkAccess.Local);
            VM.NoConnectivity = !VM.HasConnectivity;

            await VM.LoadRecommended();
        }

        private void AlbumCollectionViewItem_Tapped(object sender, EventArgs e)
        {
            var element = sender as StackLayout;
            var context = element.BindingContext as Models.NotationBrowseListItem;

            if (context != null)
            {
                Navigation.PushAsync(new NotationDetailsPage(context.Id));
            }
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