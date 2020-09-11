using CarpoolTracker.Models;
using CarpoolTracker.Views.Tracks;
using Xamarin.Forms;

namespace CarpoolTracker.ViewModels.Tracks
{
    public class TracksViewModel : ListViewModel<Track>
    {
        public TracksViewModel()
        {
            Title = "Traks";
        }

        protected override void OnItemTappedAsync(Track track)
        {
            base.OnItemTappedAsync(track);
            Shell.Current.GoToAsync($"{nameof(TrackDetailPage)}?{nameof(TrackDetailViewModel.ItemId)}={track.Id}");
        }

        protected override void OnNewItem(object obj)
        {
            base.OnNewItem(obj);
            Shell.Current.GoToAsync($"{nameof(TrackEditPage)}");
        }
    }
}