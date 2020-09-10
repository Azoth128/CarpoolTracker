using CarpoolTracker.ViewModels.Tracks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarpoolTracker.Views.Tracks
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrackDetailPage : ContentPage
    {
        public TrackDetailPage()
        {
            InitializeComponent();

            BindingContext = new TrackDetailViewModel();
        }
    }
}