using CarpoolTracker.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace CarpoolTracker.ViewModels
{
    public class BaseViewModel<T> : INotifyPropertyChanged
    {
        private bool isBusy = false;
        private string title = string.Empty;

        public event PropertyChangedEventHandler PropertyChanged;

        public IDataStore<T> DataStore => DependencyService.Get<IDataStore<T>>();

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected bool SetProperty<K>(
                    ref K backingStore,
            K value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<K>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        public virtual void OnAppearing()
        {
        }
    }
}