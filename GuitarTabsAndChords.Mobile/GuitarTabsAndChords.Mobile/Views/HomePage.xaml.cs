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

            await VM.LoadItems();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var element = sender as StackLayout;
            var context = element.BindingContext as Model.Notations;

            await Navigation.PushAsync(new NotationDetailsPage(context.Id));
        }
    }
}