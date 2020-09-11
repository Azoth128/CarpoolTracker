using CarpoolTracker.Models;
using CarpoolTracker.Views.Tracks;
using Xamarin.Forms;

namespace CarpoolTracker.ViewModels.Tracks
{
    public class TrackDetailViewModel : DetailViewModel<Track>
    {
        private int distance;
        private string name;

        public TrackDetailViewModel()
        {
            Title = "Track";
            EditTrackCommand = new Command(OnEditTrack);
        }

        public int Distance { get => distance; set => SetProperty(ref distance, value); }

        public Command EditTrackCommand { get; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        private void OnEditTrack(object obj)
        {
            Shell.Current.GoToAsync($"{nameof(TrackEditPage)}?{nameof(ItemId)}={ItemId}");
        }

        protected override void OnItemLoaded(Track item)
        {
            Name = item.Name;
            Distance = item.Distance;
        }
    }
}