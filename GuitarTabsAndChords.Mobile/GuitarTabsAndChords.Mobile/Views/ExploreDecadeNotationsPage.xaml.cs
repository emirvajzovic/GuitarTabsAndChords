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
    public partial class ExploreDecadeNotationsPage : ContentPage
    {
        private readonly ExploreDecadeNotationsViewModel VM;

        public ExploreDecadeNotationsPage(int Decade)
        {
            InitializeComponent();
            BindingContext = VM = new ExploreDecadeNotationsViewModel(Decade);
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

        private async void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            await VM.LoadNotations();
        }
    }
}