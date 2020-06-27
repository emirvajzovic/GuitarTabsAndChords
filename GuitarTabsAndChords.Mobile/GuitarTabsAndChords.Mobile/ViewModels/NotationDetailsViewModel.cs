using GuitarTabsAndChords.Mobile.Models;
using GuitarTabsAndChords.Mobile.Services;
using GuitarTabsAndChords.Mobile.Views;
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
    public class NotationDetailsViewModel : BaseViewModel
    {
        private readonly APIService _serviceNotations = new APIService("Notations");
        private readonly APIService _serviceRatings = new APIService("Ratings");
        private readonly APIService _serviceFavorites = new APIService("Favorites");
        private int _notationId;

        private Model.Notations _notation;
        public Model.Notations Notation
        {
            get { return _notation; }
            set { SetProperty(ref _notation, value); }
        }

        private string _lastEditInfo;
        public string LastEditInfo
        {
            get { return _lastEditInfo; }
            set { SetProperty(ref _lastEditInfo, value); }
        }


        private Command InitCommand;
        public ICommand RateStarCommand { get; set; }
        public ICommand SuggestCorrectionCommand { get; set; }

        private ToolbarItem _favoriteToolbarItem;
        private readonly INavigation Navigation;

        public bool HasFavoritedNotation { get; set; } = false;


        public int Rating { get; set; }

        #region stars

        private Star _star1;
        public Star Star1
        {
            get { return _star1; }
            set { SetProperty(ref _star1, value); }
        }
        private Star _star2;
        public Star Star2
        {
            get { return _star2; }
            set { SetProperty(ref _star2, value); }
        }
        private Star _star3;
        public Star Star3
        {
            get { return _star3; }
            set { SetProperty(ref _star3, value); }
        }
        private Star _star4;
        public Star Star4
        {
            get { return _star4; }
            set { SetProperty(ref _star4, value); }
        }
        private Star _star5;
        public Star Star5
        {
            get { return _star5; }
            set { SetProperty(ref _star5, value); }
        }

        #endregion

        public NotationDetailsViewModel(int NotationId, ToolbarItem favoriteToolbarItem, INavigation navigation)
        {
            _notationId = NotationId;
            _favoriteToolbarItem = favoriteToolbarItem;
            Navigation = navigation;
            InitCommand = new Command(async () => await Init());
            InitCommand.Execute(null);

            RateStarCommand = new Command<string>(async (Rating) => await RateStar(Rating));
            SuggestCorrectionCommand = new Command(async () => await SuggestCorrection());

            Star1 = new Star();
            Star2 = new Star();
            Star3 = new Star();
            Star4 = new Star();
            Star5 = new Star();

            _favoriteToolbarItem.IconImageSource = ImageSource.FromFile("star_empty.png");
        }

        private async Task SuggestCorrection()
        {
            await Navigation.PushAsync(new NotationSuggestCorrectionPage(_notationId));
        }

        private async Task Init()
        {
            await LoadNotation();

            await LoadExistingRating();

            await LoadFavoriteButton();

            UpdateRatingStars();
        }


        private async Task LoadNotation()
        {
            Notation = await _serviceNotations.GetById<Model.Notations>(_notationId);
            LastEditInfo = "on " + Notation.LastEditted.ToShortDateString();
            Title = Notation.Type.ToString() + "s";
        }

        #region star rating
        private async Task LoadExistingRating()
        {
            var request = new Model.Requests.RatingsSearchRequest
            {
                NotationId = _notationId
            };
            var ExistingRating = await _serviceRatings.Get<List<Model.Ratings>>(request);
            if (ExistingRating.Count > 0)
            {
                Rating = ExistingRating[0].Rating;
            }
        }



        private void UpdateRatingStars()
        {
            var star_emptyinside = new Star { Image = "star_empty.png" };
            var Star_Filled = new Star { Image = "star_filled.png" };

            Star1 = star_emptyinside;
            Star2 = star_emptyinside;
            Star3 = star_emptyinside;
            Star4 = star_emptyinside;
            Star5 = star_emptyinside;

            if (Rating >= 1)
                Star1 = Star_Filled;
            if (Rating >= 2)
                Star2 = Star_Filled;
            if (Rating >= 3)
                Star3 = Star_Filled;
            if (Rating >= 4)
                Star4 = Star_Filled;
            if (Rating == 5)
                Star5 = Star_Filled;
        }


        private async Task RateStar(string NewRating)
        {
            int RatingNum = int.TryParse(NewRating, out int value) ? value : 0;
            if (RatingNum >= 1 && RatingNum <= 5)
            {

                var request = new Model.Requests.RatingsInsertRequest
                {
                    NotationId = _notationId,
                    Rating = RatingNum
                };

                Rating = RatingNum;

                UpdateRatingStars();

                await _serviceRatings.Insert<Model.Ratings>(request, "RateNotation");

            }
        }
        #endregion

        #region favorite
        private async Task LoadFavoriteButton()
        {
            var entity = await _serviceFavorites.GetById<Model.Favorites>(_notationId);

            if (entity != null)
            {
                _favoriteToolbarItem.IconImageSource = ImageSource.FromFile("star_filled.png");
                HasFavoritedNotation = true;
            }
        }

        public async void ToggleFavoriteNotation()
        {
            if (HasFavoritedNotation)
            { // unfavoriting
                var success = await _serviceFavorites.Delete<bool>(_notationId);
                if (success)
                {
                    _favoriteToolbarItem.IconImageSource = ImageSource.FromFile("star_empty.png");
                    HasFavoritedNotation = false;

                    NotationStorageHelper.Remove(_notationId);
                }
            }
            else
            { // favoriting
                var request = new Model.Requests.FavoritesInsertRequest
                {
                    NotationId = _notationId
                };
                var entity = await _serviceFavorites.Insert<Model.Favorites>(request);
                if (entity != null)
                {
                    _favoriteToolbarItem.IconImageSource = ImageSource.FromFile("star_filled.png");
                    HasFavoritedNotation = true;

                    NotationStorageHelper.Add(Notation);
                }
            }
        }

        #endregion
    }
}
