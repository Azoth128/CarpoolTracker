using CarpoolTracker.Models;
using System;
using Xamarin.Forms;

namespace CarpoolTracker.ViewModels.Tracks
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class TrackEditViewModel : EditViewModel<Track>
    {
        private int distance;
        private string name;

        public TrackEditViewModel()
        {
            Title = "Track";
        }

        public int Distance { get => distance; set => SetProperty(ref distance, value); }
        public string Name { get => name; set => SetProperty(ref name, value); }

        private void GoBack()
        {
            if (IsInsert)
                Shell.Current.GoToAsync($"..");
            else
                Shell.Current.GoToAsync($"..?{nameof(TrackDetailViewModel.TrackId)}={ItemId}");
        }

        protected override bool CanSave(object arg)
        {
            return Name != "" || Distance > 0;
        }

        protected override void OnAfterSave()
        {
            GoBack();
        }

        protected override void OnCancel(object obj)
        {
            GoBack();
        }

        protected override void OnItemLoaded(Track item)
        {
            base.OnItemLoaded(item);
            Distance = item.Distance;
            Name = item.Name;
        }

        protected override void OnSave(Track item)
        {
            item.Distance = Distance;
            item.Name = Name;
        }
    }
}