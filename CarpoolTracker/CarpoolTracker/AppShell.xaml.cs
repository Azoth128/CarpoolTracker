using CarpoolTracker.Views.People;
using CarpoolTracker.Views.Tracks;
using Xamarin.Forms;

namespace CarpoolTracker
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(PersonDetailPage), typeof(PersonDetailPage));
            Routing.RegisterRoute(nameof(PersonEditPage), typeof(PersonEditPage));
            Routing.RegisterRoute(nameof(TrackDetailPage), typeof(TrackDetailPage));
            Routing.RegisterRoute(nameof(TrackEditPage), typeof(TrackEditPage));
        }
    }
}