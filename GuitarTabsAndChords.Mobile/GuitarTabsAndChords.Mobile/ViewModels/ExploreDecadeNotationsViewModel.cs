﻿using GuitarTabsAndChords.Mobile.Models;
using GuitarTabsAndChords.Mobile.Services;
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
    public class ExploreDecadeNotationsViewModel : BaseViewModel
    {
        private readonly APIService _serviceNotations = new APIService("Notations");
        private readonly int _decade;

        public ObservableCollection<Models.NotationBrowseListItem> NotationList { get; set; } = new ObservableCollection<NotationBrowseListItem>();
        public ObservableCollection<NotationSortPickerItem> NotationSortList { get; set; }
        private NotationSortPickerItem _sortingMode;
        public NotationSortPickerItem SortingMode
        {
            get { return _sortingMode; }
            set { SetProperty(ref _sortingMode, value); }
        }

        public ExploreDecadeNotationsViewModel(int Decade)
        {
            _decade = Decade;
            Title = $"Explore {_decade}";
            NotationSortList = new ObservableCollection<NotationSortPickerItem>(NotationSortHelper.GetSortPickerItems());
            foreach (var item in NotationSortList)
            {
                if (item.Value == NotationSort.RECENTLY_ADDED)
                    SortingMode = item;
            }
        }


        public async Task LoadNotations()
        {
            NotationList.Clear();

            var request = new Model.Requests.NotationsSearchRequest
            {
                Decade = _decade,
                Filter = (int)ReviewStatus.Approved,
                Sort = SortingMode.Value
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
