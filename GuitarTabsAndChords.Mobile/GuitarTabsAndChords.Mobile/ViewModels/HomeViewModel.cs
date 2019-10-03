using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using GuitarTabsAndChords.Mobile.Models;
using GuitarTabsAndChords.Mobile.Views;
using System.Collections.Generic;

namespace GuitarTabsAndChords.Mobile.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ObservableCollection<Model.Notations> RecommendedList { get; set; }

        private readonly APIService _serviceNotations = new APIService("Notations");

        public HomeViewModel()
        {
            Title = "Home";
            RecommendedList = new ObservableCollection<Model.Notations>();
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
                foreach (var item in items)
                {
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