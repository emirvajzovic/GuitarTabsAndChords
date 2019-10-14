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
    public class FavoritesViewModel : BaseViewModel
    {
        public ObservableCollection<Models.NotationFavoritesListItem> FavoritesList { get; set; }

        private readonly APIService _serviceFavorites = new APIService("Favorites");

        public ICommand ToggleFavoriteCommand { get; set; }
        private bool _nothingToSee = false;

        public bool NothingToSee
        {
            get { return _nothingToSee; }
            set { SetProperty(ref _nothingToSee, value); }
        }

        public FavoritesViewModel()
        {
            Title = "My Favorites";
            FavoritesList = new ObservableCollection<Models.NotationFavoritesListItem>();

            ToggleFavoriteCommand = new Command<Models.NotationFavoritesListItem>(async (favorite) => await ToggleFavorite(favorite));
        }

        public async Task LoadItems()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                FavoritesList.Clear();

                var items = await _serviceFavorites.Get<List<Models.NotationFavoritesListItem>>(null);
                NothingToSee = items.Count == 0;

                foreach (var item in items)
                {
                    FavoritesList.Add(item);
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

        public async Task ToggleFavorite(NotationFavoritesListItem favorite)
        {
            if (favorite.IsFavorite)
            { // unfavoriting
                var success = await _serviceFavorites.Delete<bool>(favorite.NotationId);
                if (success)
                {
                    favorite.IsFavorite = false;
                }
            }
            else
            { // favoriting
                var request = new Model.Requests.FavoritesInsertRequest
                {
                    NotationId = favorite.NotationId
                };
                var entity = await _serviceFavorites.Insert<Model.Favorites>(request);
                if (entity != null)
                {
                    favorite.IsFavorite = true;
                }
            }

            List<Models.NotationFavoritesListItem> TempList = new List<NotationFavoritesListItem>();
            foreach (var item in FavoritesList)
            {
                TempList.Add(item);
            }

            FavoritesList.Clear();

            foreach (var item in TempList)
            {
                FavoritesList.Add(item);
            }


        }
    }
}