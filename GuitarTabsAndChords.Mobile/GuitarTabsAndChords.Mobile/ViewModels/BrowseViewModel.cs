using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using GuitarTabsAndChords.Mobile.Models;
using GuitarTabsAndChords.Mobile.Views;
using System.Collections.Generic;
using System.Windows.Input;

namespace GuitarTabsAndChords.Mobile.ViewModels
{
    public class BrowseViewModel : BaseViewModel
    {
        private readonly APIService _serviceNotations = new APIService("Notations");
        private readonly APIService _serviceSearch = new APIService("Search");

        public ICommand SearchCommand { get; set; }
        public ICommand AddNotationCommand { get; set; }
        private readonly INavigation _navigation;

        public ObservableCollection<Models.NotationBrowseListItem> ThisWeekTop5List { get; set; } = new ObservableCollection<NotationBrowseListItem>();
        public ObservableCollection<Model.SearchResult> SearchResultList { get; set; } = new ObservableCollection<Model.SearchResult>();

        private string _searchText = string.Empty;
        public string SearchText
        {
            get { return _searchText; }
            set { SetProperty(ref _searchText, value); }
        }
        private bool _searchResultsVisible = false;
        public bool SearchResultsVisible
        {
            get { return _searchResultsVisible; }
            set { SetProperty(ref _searchResultsVisible, value); }
        }


        private bool _isBrowseVisible = true;
        public bool IsBrowseVisible
        {
            get { return _isBrowseVisible; }
            set { SetProperty(ref _isBrowseVisible, value); }
        }

        public BrowseViewModel(INavigation navigation)
        {
            Title = "Browse";
            SearchCommand = new Command(async () => await Search());
            AddNotationCommand = new Command(async () => await AddNotation());
            _navigation = navigation;
        }

        public async Task AddNotation()
        {
            await _navigation.PushAsync(new AddNotationPage());
        }

        public async Task Search()
        {
            if(string.IsNullOrWhiteSpace(SearchText))
            {
                IsBrowseVisible = true;
                SearchResultsVisible = false;
                return;
            }

            var request = new Model.Requests.SearchRequest
            {
                SearchString = SearchText
            };
            var list = await _serviceSearch.Get<List<Model.SearchResult>>(request);
            SearchResultList.Clear();

            SearchResultsVisible = true;
            IsBrowseVisible = false;

            if(list.Count != 0)
            {
                foreach (var item in list)
                {
                    SearchResultList.Add(item);
                }
            }
            else
            {
                SearchResultList.Add(new Model.SearchResult
                {
                    ResultText = "No results found."
                });
            }
        }

        public async Task LoadItems()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                ThisWeekTop5List.Clear();

                var items = await _serviceNotations.Get<List<Models.NotationBrowseListItem>>(null, "ThisWeekTop5");
                foreach (var item in items)
                {
                    UpdateStarRating(item);

                    ThisWeekTop5List.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private static void UpdateStarRating(NotationBrowseListItem item)
        {
            if (item.Rating >= 4.25)
            {
                if (item.Rating >= 4.75)
                    item.Star5.Slika = "star_filled.png";
                else
                    item.Star5.Slika = "star_half.png";
            }
            if (item.Rating >= 3.25)
            {
                if (item.Rating >= 3.75)
                    item.Star4.Slika = "star_filled.png";
                else
                    item.Star4.Slika = "star_half.png";
            }
            if (item.Rating >= 2.25)
            {
                if (item.Rating >= 2.75)
                    item.Star3.Slika = "star_filled.png";
                else
                    item.Star3.Slika = "star_half.png";
            }
            if (item.Rating >= 1.50)
            {
                if (item.Rating >= 1.75)
                    item.Star2.Slika = "star_filled.png";
                else
                    item.Star2.Slika = "star_half.png";
            }
            if (item.Rating >= 1.00)
            {
                item.Star1.Slika = "star_filled.png";
            }
        }
    }
}