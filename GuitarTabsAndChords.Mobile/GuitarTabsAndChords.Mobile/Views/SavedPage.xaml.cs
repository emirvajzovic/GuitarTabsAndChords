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
    public partial class SavedPage : ContentPage
    {
        private readonly SavedPageViewModel VM;

        public SavedPage()
        {
            InitializeComponent();
            BindingContext = VM = new SavedPageViewModel();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                Model.Notations item = e.Item as Model.Notations;
                await Navigation.PushAsync(new NotationDetailsPage(item.Id));
            }
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await VM.LoadItems();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}