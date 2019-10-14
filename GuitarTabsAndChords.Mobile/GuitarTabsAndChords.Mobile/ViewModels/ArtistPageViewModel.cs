using GuitarTabsAndChords.Mobile.Models;
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
    public class ArtistPageViewModel : BaseViewModel
    {
        private readonly APIService _serviceArtists = new APIService("Artists");
        private readonly APIService _serviceAlbums = new APIService("Albums");
        private readonly APIService _serviceNotations = new APIService("Notations");

        private readonly int _artistId;
        private Model.Artists _artist;
        public Model.Artists Artist
        {
            get { return _artist; }
            set { SetProperty(ref _artist, value); }
        }
        private bool _nothingToSeeNotations = false;

        public bool NothingToSeeNotations
        {
            get { return _nothingToSeeNotations; }
            set { SetProperty(ref _nothingToSeeNotations, value); }
        }

        private bool _nothingToSeeAlbums = false;

        public bool NothingToSeeAlbums
        {
            get { return _nothingToSeeAlbums; }
            set { SetProperty(ref _nothingToSeeAlbums, value); }
        }

        public ICommand InitCommand { get; set; }

        public ObservableCollection<Models.NotationBrowseListItem> NotationList { get; set; } = new ObservableCollection<NotationBrowseListItem>();
        public ObservableCollection<Model.Albums> AlbumsList { get; set; } = new ObservableCollection<Model.Albums>();

        public ArtistPageViewModel(int ArtistId)
        {
            _artistId = ArtistId;
            InitCommand = new Command(async () => await LoadAlbums());
            InitCommand.Execute(null);
        }

        public async Task Init()
        {
            await LoadArtist();
            await LoadNotations();
        }

        private async Task LoadArtist()
        {
            Artist = await _serviceArtists.GetById<Model.Artists>(_artistId);
            Title = "Artist details - " + Artist.Name;
        }

        public async Task LoadNotations()
        {
            NotationList.Clear();

            var request = new Model.Requests.NotationsSearchRequest
            {
                ArtistId = _artistId
            };
            var list = await _serviceNotations.Get<List<Models.NotationBrowseListItem>>(request);
            NothingToSeeNotations = list.Count == 0;
            int counter = 0;
            foreach (var item in list.GetRange(0, Math.Min(list.Count, 5)))
            {
                UpdateStarRating(item);
                item.Counter = ++counter;
                NotationList.Add(item);
            }
        }

        public async Task LoadAlbums()
        {
            AlbumsList.Clear();

            var request = new Model.Requests.AlbumsSearchRequest
            {
                ArtistId = _artistId
            };
            var list = await _serviceAlbums.Get<List<Model.Albums>>(request);
            NothingToSeeAlbums = list.Count == 0;
            foreach (var item in list)
            {
                if(item.AlbumCover.Length == 0)
                {
                    item.AlbumCover = File.ReadAllBytes("logo.png");
                }
                AlbumsList.Add(item);
            }
        }
        private static void UpdateStarRating(NotationBrowseListItem item)
        {
            if (item.Rating >= 4.25)
            {
                if (item.Rating >= 4.75)
                    item.Star5.Image = "star_filled.png";
                else
                    item.Star5.Image = "star_half.png";
            }
            if (item.Rating >= 3.25)
            {
                if (item.Rating >= 3.75)
                    item.Star4.Image = "star_filled.png";
                else
                    item.Star4.Image = "star_half.png";
            }
            if (item.Rating >= 2.25)
            {
                if (item.Rating >= 2.75)
                    item.Star3.Image = "star_filled.png";
                else
                    item.Star3.Image = "star_half.png";
            }
            if (item.Rating >= 1.50)
            {
                if (item.Rating >= 1.75)
                    item.Star2.Image = "star_filled.png";
                else
                    item.Star2.Image = "star_half.png";
            }
            if (item.Rating >= 1.00)
            {
                item.Star1.Image = "star_filled.png";
            }
        }

    }
}
