using CarpoolTracker.Models;
using System;
using Xamarin.Forms;

namespace CarpoolTracker.ViewModels
{
    public abstract class EditViewModel<T> : BaseViewModel<T> where T : IDataModel, new()
    {
        private string itemId;

        public EditViewModel()
        {
            SaveCommand = new Command(OnSaveInternal, CanSave);
            CancelCommand = new Command(OnCancel);
            PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();
        }

        protected bool IsInsert { get => ItemId == null || ItemId == ""; }

        public Command CancelCommand { get; }

        public string ItemId { get => itemId; set { itemId = value; LoadItem(); } }

        public Command SaveCommand { get; }

        private async void LoadItem()
        {
            IsBusy = true;
            try
            {
                var item = await DataStore.GetAsync(ItemId);
                OnItemLoaded(item);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void OnSaveInternal(object obj)
        {
            T item;
            if (IsInsert)
                item = new T() { Id = Guid.NewGuid().ToString() };
            else
                item = await DataStore.GetAsync(ItemId);

            OnSave(item);

            if (IsInsert)
                await DataStore.AddAsync(item);
            else
                await DataStore.UpdateAsync(item);

            OnAfterSave();
        }

        protected abstract bool CanSave(object arg);

        protected abstract void OnAfterSave();

        protected abstract void OnCancel(object obj);

        protected virtual void OnItemLoaded(T item)
        {
        }

        protected abstract void OnSave(T item);
    }
}