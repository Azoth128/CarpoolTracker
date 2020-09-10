using CarpoolTracker.ViewModels.Tracks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarpoolTracker.Views.Tracks
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TracksPage : ContentPage
    {
        private readonly TracksViewModel viewModel;

        public TracksPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new TracksViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
}