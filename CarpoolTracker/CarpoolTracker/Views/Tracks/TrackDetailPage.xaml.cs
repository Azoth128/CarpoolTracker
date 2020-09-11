using CarpoolTracker.ViewModels.Tracks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarpoolTracker.Views.Tracks
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrackDetailPage : ContentPage
    {
        private readonly TrackDetailViewModel viewModel;

        public TrackDetailPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new TrackDetailViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
}