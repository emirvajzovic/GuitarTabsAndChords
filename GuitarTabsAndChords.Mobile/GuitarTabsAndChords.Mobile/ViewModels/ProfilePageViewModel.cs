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
    public class ProfilePageViewModel : BaseViewModel
    {
        private readonly APIService _serviceUsers = new APIService("Users");
        private readonly APIService _serviceNotations = new APIService("Notations");

        private int _userId;
        private readonly ToolbarItem _editProfileToolbarItem;
        private Model.Users _user;
        public Model.Users User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }
        public int UserId { get; set; }
        private bool _nothingToSee = false;
        public bool NothingToSee
        {
            get { return _nothingToSee; }
            set { SetProperty(ref _nothingToSee, value); }
        }

        public ObservableCollection<Models.NotationBrowseListItem> NotationList { get; set; } = new ObservableCollection<NotationBrowseListItem>();

        public ProfilePageViewModel(int UserId, ToolbarItem editProfileToolbarItem)
        {
            this.UserId = UserId;
            _editProfileToolbarItem = editProfileToolbarItem;
        }

        public async Task Init()
        {
            _userId = UserId != 0 ? UserId : (await APIService.GetCurrentUser()).Id;
            await LoadUser();
            await LoadNotations();
        }

        private async Task LoadUser()
        {
            User = await _serviceUsers.GetById<Model.Users>(_userId);
            if (User.ProfilePicture.Length == 0)
            {
                User.ProfilePicture = File.ReadAllBytes("logo.png");
            }

            Title = "User Profile - " + User.Username;
            if (User.Id == (await APIService.GetCurrentUser()).Id)
            {
                _editProfileToolbarItem.IconImageSource = ImageSource.FromFile("icon_edit.png");
            }
            else
            {
                _editProfileToolbarItem.IconImageSource = null;
            }
        }

        public async Task LoadNotations()
        {
            NotationList.Clear();

            var request = new Model.Requests.NotationsSearchRequest
            {
                UserId = _userId,
                Filter = (int)ReviewStatus.Approved
            };
            var list = await _serviceNotations.Get<List<Models.NotationBrowseListItem>>(request);
            NothingToSee = list.Count == 0;
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
