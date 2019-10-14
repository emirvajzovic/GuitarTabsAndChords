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
        public List<Models.MenuItem> MenuItems { get; set; } = new List<Models.MenuItem>();

        private readonly APIService _serviceNotations = new APIService("Notations");

        public HomeViewModel()
        {
            Title = "Home";
            RecommendedList = new ObservableCollection<Model.Notations>();
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
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                RecommendedList.Clear();

                var items = await _serviceNotations.Get<List<Model.Notations>>(null);
                foreach (var item in items.GetRange(0, Math.Min(10, items.Count)))
                {
                    if (item.Song.Album.AlbumCover.Length == 0)
                    {
                        item.Song.Album.AlbumCover = File.ReadAllBytes("logo.png");
                    }
                    RecommendedList.Add(item);
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
    }
}