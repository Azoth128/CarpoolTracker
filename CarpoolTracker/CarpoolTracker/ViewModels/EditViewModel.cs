using CarpoolTracker.Models;
using System;
using Xamarin.Forms;

namespace CarpoolTracker.ViewModels
{
    public abstract class EditViewModel<T> : DetailViewModel<T> where T : class, IDataModel, new()
    {
        public EditViewModel()
        {
            SaveCommand = new Command(OnSaveInternal, _ => CanSave());
            CancelCommand = new Command(OnCancel);
            PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();
        }

        protected bool IsInsert { get => ItemId == null || ItemId == ""; }

        public Command CancelCommand { get; }

        public Command SaveCommand { get; }

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

        protected abstract bool CanSave();

        protected abstract void OnAfterSave();

        protected abstract void OnCancel();

        protected abstract void OnSave(T item);
    }
}