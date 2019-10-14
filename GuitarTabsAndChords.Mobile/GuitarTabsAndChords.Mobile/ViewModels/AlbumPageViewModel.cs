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
    public class AlbumPageViewModel : BaseViewModel
    {
        private readonly APIService _serviceAlbums = new APIService("Albums");
        private readonly APIService _serviceSongs = new APIService("Songs");

        private readonly int _albumId;
        private Model.Albums _album;
        public Model.Albums Album
        {
            get { return _album; }
            set { SetProperty(ref _album, value); }
        }
        private bool _nothingToSeeSongs = false;

        public bool NothingToSeeSongs
        {
            get { return _nothingToSeeSongs; }
            set { SetProperty(ref _nothingToSeeSongs, value); }
        }

        public ObservableCollection<Model.Songs> SongList { get; set; } = new ObservableCollection<Model.Songs>();

        public AlbumPageViewModel(int AlbumId)
        {
            _albumId = AlbumId;
        }

        public async Task Init()
        {
            await LoadAlbum();
            await LoadSongs();
        }

        private async Task LoadAlbum()
        {
            Album = await _serviceAlbums.GetById<Model.Albums>(_albumId);
            if (Album.AlbumCover.Length == 0)
            {
                Album.AlbumCover = File.ReadAllBytes("logo.png");
            }
            Title = "Album details - " + Album.Name;
        }

        public async Task LoadSongs()
        {
            SongList.Clear();

            var request = new Model.Requests.SongsSearchRequest
            {
                AlbumId = _albumId
            };
            var list = await _serviceSongs.Get<List<Model.Songs>>(request);
            NothingToSeeSongs = list.Count == 0;
            int counter = 0;
            foreach (var item in list)
            {
                SongList.Add(item);
                item.Counter = ++counter;
            }
        }

    }
}
