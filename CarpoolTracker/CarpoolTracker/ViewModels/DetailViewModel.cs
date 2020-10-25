using System;
using Xamarin.Forms;

namespace CarpoolTracker.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public abstract class DetailViewModel<T> : BaseViewModel<T> where T : class
    {
        private string itemId;

        public DetailViewModel() : base()
        {
            itemId = "";
        }

        public string ItemId
        {
            get => itemId;
            set
            {
                if (!Guid.TryParse(value, out _))
                    throw new ArgumentOutOfRangeException();

                itemId = value ?? "";
                LoadItem();
            }
        }

        private async void LoadItem()
        {
            if (itemId == "")
            {
                OnItemLoaded(null);
                return;
            }
            IsBusy = true;
            try
            {
                var item = await DataStore.GetAsync(Guid.Parse(ItemId));
                OnItemLoaded(item);
            }
            finally
            {
                IsBusy = false;
            }
        }

        protected abstract void OnItemLoaded(T item);
    }
}