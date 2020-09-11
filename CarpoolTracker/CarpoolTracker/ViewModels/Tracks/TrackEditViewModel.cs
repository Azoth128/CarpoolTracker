using CarpoolTracker.Models;
using System;
using Xamarin.Forms;

namespace CarpoolTracker.ViewModels.Tracks
{
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

        protected override bool CanSave() => Name != "" || Distance > 0;

        protected async override void OnAfterSave() => await Shell.Current.Navigation.PopAsync();

        protected async override void OnCancel() => await Shell.Current.Navigation.PopAsync();

        protected override void OnItemLoaded(Track item)
        {
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