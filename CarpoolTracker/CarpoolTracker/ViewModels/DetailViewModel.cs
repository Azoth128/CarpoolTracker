using Xamarin.Forms;

namespace CarpoolTracker.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public abstract class DetailViewModel<T> : BaseViewModel<T> where T : class
    {
        private string itemId;

        public string ItemId { get => itemId; set { itemId = value ?? ""; LoadItem(); } }

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
                var item = await DataStore.GetAsync(ItemId);
                OnItemLoaded(item);
            }
            finally
            {
                IsBusy = false;
            }
        }

        protected abstract void OnItemLoaded(T item);

        public override void OnAppearing()
        {
            base.OnAppearing();
            if (ItemId != "")
                LoadItem();
        }
    }
}