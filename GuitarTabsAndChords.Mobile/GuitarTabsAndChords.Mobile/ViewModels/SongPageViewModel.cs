using GuitarTabsAndChords.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GuitarTabsAndChords.Mobile.ViewModels
{
    public class SongPageViewModel : BaseViewModel
    {
        private readonly APIService _serviceSongs = new APIService("Songs");
        private readonly APIService _serviceNotations = new APIService("Notations");

        private readonly int _songId;
        private Model.Songs _song;
        public Model.Songs Song
        {
            get { return _song; }
            set { SetProperty(ref _song, value); }
        }

        public ObservableCollection<Models.NotationBrowseListItem> NotationList { get; set; } = new ObservableCollection<NotationBrowseListItem>();

        public SongPageViewModel(int SongId)
        {
            _songId = SongId;
        }

        public async Task Init()
        {
            await LoadSong();
            await LoadNotations();
        }

        private async Task LoadSong()
        {
            Song = await _serviceSongs.GetById<Model.Songs>(_songId);
            Title = "Song details - " + Song.Name;
        }

        public async Task LoadNotations()
        {
            NotationList.Clear();

            var request = new Model.Requests.NotationsSearchRequest
            {
                SongId = _songId
            };
            var list = await _serviceNotations.Get<List<Models.NotationBrowseListItem>>(request);
            foreach (var item in list)
            {
                UpdateStarRating(item);
                NotationList.Add(item);
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
