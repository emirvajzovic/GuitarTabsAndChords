using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using GuitarTabsAndChords.Mobile.Models;
using GuitarTabsAndChords.Mobile.Services;
using Xamarin.Essentials;

namespace GuitarTabsAndChords.Mobile.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private bool _hasConnectivity;

        public bool HasConnectivity
        {
            get
            {
                this.HasConnectivity = (Connectivity.NetworkAccess >= NetworkAccess.Local);
                return _hasConnectivity;
            }
            set
            {
                SetProperty(ref _hasConnectivity, value);
            }
        }

        private bool _noConnectivity;

        public bool NoConnectivity
        {
            get { return _noConnectivity; }
            set { SetProperty(ref _noConnectivity, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
