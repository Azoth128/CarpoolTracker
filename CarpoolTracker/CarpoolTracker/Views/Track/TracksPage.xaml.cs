using CarpoolTracker.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarpoolTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TracksPage : ContentPage
    {
        private TracksViewModel viewModel;
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