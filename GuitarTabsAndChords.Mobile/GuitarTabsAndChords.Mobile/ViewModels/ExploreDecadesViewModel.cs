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
    public class ExploreDecadesViewModel : BaseViewModel
    {
        private readonly APIService _serviceNotations = new APIService("Notations");

        public ICommand InitCommand { get; set; }

        public ObservableCollection<Decade> ItemList { get; set; } = new ObservableCollection<Decade>();

        public ExploreDecadesViewModel()
        {
            Title = "Explore Decades";
        }

        public async Task Init()
        {
            await LoadDecades();
        }

        public async Task LoadDecades()
        {
            ItemList.Clear();

            var list = await _serviceNotations.Get<List<int>>(null, "GetDecades");

            foreach (var item in list)
            {
                ItemList.Add(new Decade
                {
                    DecadeInt = item,
                    Text = item + "s"
                });
            }
        }


    }
}
