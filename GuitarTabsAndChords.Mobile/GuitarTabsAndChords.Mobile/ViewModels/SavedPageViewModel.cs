using GuitarTabsAndChords.Mobile.Models;
using GuitarTabsAndChords.Mobile.Services;
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
    class SavedPageViewModel : BaseViewModel
    {
        public ObservableCollection<Model.Notations> SavedList { get; set; }

        private readonly APIService _serviceFavorites = new APIService("Favorites");

        public ICommand ToggleFavoriteCommand { get; set; }

        private bool _nothingToSee = false;
        public bool NothingToSee
        {
            get { return _nothingToSee; }
            set { SetProperty(ref _nothingToSee, value); }
        }

        public SavedPageViewModel()
        {
            Title = "Saved Notations";
            SavedList = new ObservableCollection<Model.Notations>();

            ToggleFavoriteCommand = new Command<Models.NotationFavoritesListItem>(async (favorite) => await ToggleFavorite(favorite));
        }

        public async Task LoadItems()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                SavedList.Clear();

                var notationList = await NotationStorageHelper.GetAll();

                NothingToSee = notationList.Count == 0;

                foreach (var item in notationList)
                {
                    SavedList.Add(item);
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
            }
        }
    }
}
