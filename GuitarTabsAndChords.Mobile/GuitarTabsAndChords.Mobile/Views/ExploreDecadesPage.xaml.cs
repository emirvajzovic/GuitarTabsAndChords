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
    public partial class ExploreDecadesPage : ContentPage
    {
        private readonly ExploreGenresViewModel VM;

        public ExploreDecadesPage()
        {
            InitializeComponent();
            BindingContext = VM = new ExploreGenresViewModel();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                Genres genre = e.Item as Genres;
                //await Navigation.PushAsync(new ExploreDecadeNotationsPage());
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