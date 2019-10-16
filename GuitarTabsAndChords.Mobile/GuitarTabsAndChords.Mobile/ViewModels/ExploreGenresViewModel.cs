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
    public class ExploreGenresViewModel : BaseViewModel
    {
        private readonly APIService _serviceGenres = new APIService("Genres");

        public ICommand InitCommand { get; set; }

        public ObservableCollection<Model.Genres> ItemList { get; set; } = new ObservableCollection<Model.Genres>();

        public ExploreGenresViewModel()
        {
            Title = "Explore Genres";
        }

        public async Task Init()
        {
            await LoadGenres();
        }

        public async Task LoadGenres()
        {
            ItemList.Clear();

            var request = new Model.Requests.GenresSearchRequest
            {
                Filter = (int)Model.ReviewStatus.Approved
            };
            var list = await _serviceGenres.Get<List<Model.Genres>>(request);

            foreach (var item in list)
            {
                if (item.NumberOfSongs != 0)
                    ItemList.Add(item);
            }
        }


    }
}
