using CarpoolTracker.Models;
using CarpoolTracker.Views;
using Xamarin.Forms;

namespace CarpoolTracker.ViewModels
{
    [QueryProperty(nameof(TrackId), nameof(TrackId))]
    public class TrackDetailViewModel : BaseViewModel<Track>
    {
        private string trackId;

        private string name;
        private int distance;

        public string TrackId
        {
            get => trackId;
            set
            {
                trackId = value;
                LoadTrack();
            }
        }

        public string Name { get => name; set => SetProperty(ref name, value); }
        public int Distance { get => distance; set => SetProperty(ref distance, value); }

        public Command EditTrackCommand { get; }

        public TrackDetailViewModel()
        {
            Title = "Track";
            EditTrackCommand = new Command(OnEditTrack);
        }

        private void OnEditTrack(object obj)
        {
            Shell.Current.GoToAsync($"{nameof(TrackEditPage)}?{nameof(TrackEditViewModel.TrackId)}={TrackId}");
        }

        private async void LoadTrack()
        {
            IsBusy = true;
            try
            {
                var track = await DataStore.GetAsync(TrackId);

                Name = track.Name;
                Distance = track.Distance;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}