using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using GuitarTabsAndChords.Mobile.Models;
using GuitarTabsAndChords.Mobile.Views;
using System.Collections.Generic;
using System.IO;

namespace GuitarTabsAndChords.Mobile.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ObservableCollection<Model.Notations> RecommendedList { get; set; }
        public ObservableCollection<Model.Notations> PopularTabsList { get; set; }
        public ObservableCollection<Model.Notations> PopularChordsList { get; set; }
        public List<Models.MenuItem> MenuItems { get; set; } = new List<Models.MenuItem>();

        private readonly APIService _serviceNotations = new APIService("Notations");
        private readonly APIService _serviceRecommender = new APIService("Recommender");

        public HomeViewModel()
        {
            Title = "Home";
            RecommendedList = new ObservableCollection<Model.Notations>();
            PopularTabsList = new ObservableCollection<Model.Notations>();
            PopularChordsList = new ObservableCollection<Model.Notations>();
            MenuItems.Add(new Models.MenuItem
            {
                Image = "star_empty.png",
                Text = "Top 100",
                Page = typeof(Top100Page)
            });
            MenuItems.Add(new Models.MenuItem
            {
                Image = "icon_user.png",
                Text = "Profile",
                Page = typeof(ProfilePage)
            });
            MenuItems.Add(new Models.MenuItem
            {
                Image = "icon_logout.png",
                Text = "Sign Out",
                Page = null
            });
        }

        public async Task LoadItems()
        {
            await LoadRecommendedList();

            await LoadPopularTabs();

            await LoadPopularChords();
        }

        private async Task LoadRecommendedList()
        {
            RecommendedList.Clear();

            var items = await _serviceRecommender.Get<List<Model.Notations>>(null, "GetRecommendedNotations");
            foreach (var item in items.GetRange(0, Math.Min(5, items.Count)))
            {
                if (item.Song.Album.AlbumCover.Length == 0)
                {
                    item.Song.Album.AlbumCover = File.ReadAllBytes("logo.png");
                }
                RecommendedList.Add(item);
            }
        }

        private async Task LoadPopularChords()
        {
            PopularChordsList.Clear();
            var chordsRequest = new Model.Requests.NotationsSearchRequest
            {
                Type = Model.NotationType.Chord
            };
            var chords = await _serviceNotations.Get<List<Model.Notations>>(chordsRequest, "PopularNotations");
            foreach (var item in chords.GetRange(0, Math.Min(10, chords.Count)))
            {
                if (item.Song.Album.AlbumCover.Length == 0)
                {
                    item.Song.Album.AlbumCover = File.ReadAllBytes("logo.png");
                }
                PopularChordsList.Add(item);
            }
        }

        private async Task LoadPopularTabs()
        {
            PopularTabsList.Clear();
            var tabsRequest = new Model.Requests.NotationsSearchRequest
            {
                Type = Model.NotationType.Tab
            };
            var tabs = await _serviceNotations.Get<List<Model.Notations>>(tabsRequest, "PopularNotations");
            foreach (var item in tabs.GetRange(0, Math.Min(10, tabs.Count)))
            {
                if (item.Song.Album.AlbumCover.Length == 0)
                {
                    item.Song.Album.AlbumCover = File.ReadAllBytes("logo.png");
                }
                PopularTabsList.Add(item);
            }
        }
    }
}