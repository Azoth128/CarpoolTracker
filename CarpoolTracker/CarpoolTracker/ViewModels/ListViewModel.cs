using CarpoolTracker.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace CarpoolTracker.ViewModels
{
    public abstract class ListViewModel<T> : BaseViewModel<T>
    {
        public ListViewModel()
        {
            Items = new ObservableCollection<T>();

            ItemTappedCommand = new Command<T>(OnItemTappedAsync);
            LoadItemsCommand = new Command(LoadItems);
            NewItemCommand = new Command(OnNewItem);
        }

        public ObservableCollection<T> Items { get; }

        public Command<T> ItemTappedCommand { get; }

        public Command LoadItemsCommand { get; }

        public Command NewItemCommand { get; }

        private async void LoadItems()
        {
            IsBusy = true;
            try
            {
                Items.Clear();
                var items = await DataStore.GetListAsync();
                items.ForEach(item => Items.Add(item));
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

        protected virtual void OnItemTappedAsync(T item)
        {
        }

        protected virtual void OnNewItem(object obj)
        {
        }

        public virtual void OnAppearing()
        {
            LoadItems();
        }
    }
}