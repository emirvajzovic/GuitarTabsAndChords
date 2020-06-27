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
    public partial class ProfilePage : ContentPage
    {
        private readonly ProfilePageViewModel VM;


        public ProfilePage()
        {
            InitializeComponent();
            BindingContext = VM = new ProfilePageViewModel(0, EditProfileToolbarItem);
        }

        public ProfilePage(int UserId)
        {
            InitializeComponent();
            BindingContext = VM = new ProfilePageViewModel(UserId, EditProfileToolbarItem);
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
        private async void EditProfile_Clicked(object sender, EventArgs e)
        {
            if (VM.User.Id == (await APIService.GetCurrentUser()).Id)
                await Navigation.PushAsync(new EditProfilePage());
            else
                await Application.Current.MainPage.DisplayAlert("Error", "You are not authorized to edit this profile.", "OK");
        }
    }
}