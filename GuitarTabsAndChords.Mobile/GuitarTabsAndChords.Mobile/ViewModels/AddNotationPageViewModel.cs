using GuitarTabsAndChords.Mobile.Models;
using GuitarTabsAndChords.Model;
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
    public class AddNotationPageViewModel : BaseViewModel
    {
        private readonly APIService _serviceNotations = new APIService("Notations");
        private readonly APIService _serviceSongs = new APIService("Songs");
        private readonly APIService _serviceAlbums = new APIService("Albums");
        private readonly APIService _serviceArtists = new APIService("Artists");
        private readonly APIService _serviceGenres = new APIService("Genres");

        private readonly INavigation _navigation;

        private Model.Notations _notation;
        public Model.Notations Notation
        {
            get { return _notation; }
            set { SetProperty(ref _notation, value); }
        }

        public ICommand SaveNotationCommand { get; set; }

        public ObservableCollection<Model.Artists> ArtistList { get; set; } = new ObservableCollection<Model.Artists>();


        public ObservableCollection<Model.Albums> AlbumList { get; set; } = new ObservableCollection<Model.Albums>();
        public ObservableCollection<Model.Songs> SongList { get; set; } = new ObservableCollection<Model.Songs>();
        public ObservableCollection<Model.NotationType> NotationTypes { get; set; } = new ObservableCollection<Model.NotationType>();

        public int SongId;
        public int ArtistId;
        public int AlbumId;

        private string _noResultsFoundText;
        public string NoResultsFoundText
        {
            get { return _noResultsFoundText; }
            set { SetProperty(ref _noResultsFoundText, value); }
        }

        public string SongName { get; set; }
        public string AlbumName { get; set; }
        public string ArtistName { get; set; }

        public AddNotationPageViewModel(INavigation navigation)
        {
            Title = "Add notation";
            Notation = new Notations();
            SaveNotationCommand = new Command(async () => await SaveNotation());

            foreach (NotationType type in Enum.GetValues(typeof(NotationType)))
            {
                NotationTypes.Add(type);
            }

            _navigation = navigation;
        }

        private async Task SaveNotation()
        {
            if(ArtistId == 0)
            {
                // create artist
                var request = new Model.Requests.ArtistsInsertRequest
                {
                    Name = ArtistName
                };

                var artist = await _serviceArtists.Insert<Model.Artists>(request);
                if(artist != null)
                {
                    ArtistId = artist.Id;
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Failed to create artist.", "OK");
                    return;
                }
            }

            if(AlbumId == 0)
            {
                // create album
                var request = new Model.Requests.AlbumsInsertRequest
                {
                    Name = AlbumName,
                    ArtistId = ArtistId
                };

                var album = await _serviceAlbums.Insert<Model.Albums>(request);
                if (album != null)
                {
                    AlbumId = album.Id;
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Failed to create album.", "OK");
                    return;
                }
            }

            if(SongId == 0)
            {
                int GenreId;
                var GenreRequest = new Model.Requests.GenresSearchRequest
                {
                    Name = "Unknown"
                };
                var genre = await _serviceGenres.Get<List<Model.Genres>>(GenreRequest);
                if(genre.Count == 0)
                {
                    // Genre "Unknown" does not exist in database
                    var GenreInsertRequest = new Model.Requests.GenresInsertRequest
                    {
                        Name = "Unknown"
                    };
                    var GenreResult = await _serviceGenres.Insert<Model.Genres>(GenreInsertRequest);
                    if(GenreRequest != null)
                    {
                        GenreId = GenreResult.Id;
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Failed to create genre.", "OK");
                        return;
                    }
                }
                else
                {
                    GenreId = genre[0].Id;
                }

                // create song
                var request = new Model.Requests.SongsInsertRequest
                {
                    Name = SongName,
                    AlbumId = AlbumId,
                    ArtistId = ArtistId,
                    GenreId = GenreId
                };

                var song = await _serviceSongs.Insert<Model.Songs>(request);
                if (song != null)
                {
                    SongId = song.Id;
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Failed to create song.", "OK");
                }
            }

            if (SongId == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Song is required.", "OK");
                return;
            }

            Notation.SongId = SongId;
            var entity = await _serviceNotations.Insert<Model.Notations>(Notation);
            if (entity != null)
            {
                await Application.Current.MainPage.DisplayAlert("Success", "The notation is waiting approval.", "OK");
                await _navigation.PopAsync();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to create notation.", "OK");
            }
        }

        public async Task Init()
        {
            await LoadArtists();
        }

        public async Task LoadArtists()
        {
            ArtistList.Clear();

            var request = new Model.Requests.ArtistsSearchRequest
            {
                Filter = (int)ReviewStatus.Approved
            };
            var list = await _serviceArtists.Get<List<Model.Artists>>(request);
            foreach (var item in list)
            {
                ArtistList.Add(item);
            }
        }
        public async Task LoadAlbums()
        {
            AlbumList.Clear();

            var request = new Model.Requests.AlbumsSearchRequest
            {
                ArtistId = ArtistId,
                Filter = (int)ReviewStatus.Approved
            };
            var list = await _serviceAlbums.Get<List<Model.Albums>>(request);
            foreach (var item in list)
            {
                AlbumList.Add(item);
            }
        }

        public async Task LoadSongs()
        {
            SongList.Clear();

            var request = new Model.Requests.SongsSearchRequest
            {
                AlbumId = AlbumId,
                Filter = (int)ReviewStatus.Approved
            };
            var list = await _serviceSongs.Get<List<Model.Songs>>(request);
            foreach (var item in list)
            {
                SongList.Add(item);
            }
        }

      
    }
}
