using GuitarTabsAndChords.Mobile.Models;
using GuitarTabsAndChords.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GuitarTabsAndChords.Mobile.ViewModels
{
    public class ExploreArtistsViewModel : BaseViewModel
    {
        private readonly APIService _serviceArtists = new APIService("Artists");

        public ICommand InitCommand { get; set; }

        public ObservableCollection<Model.Artists> ItemList { get; set; } = new ObservableCollection<Model.Artists>();

        public ExploreArtistsViewModel()
        {
            Title = "Explore Artists";
        }

        public async Task Init()
        {
            await LoadArtists();
        }

        public async Task LoadArtists()
        {
            ItemList.Clear();

            var request = new Model.Requests.ArtistsSearchRequest
            {
                Filter = (int)Model.ReviewStatus.Approved
            };
            var list = await _serviceArtists.Get<List<Model.Artists>>(request);

            foreach (var item in list)
            {
                ItemList.Add(item);
            }
        }


    }
}
