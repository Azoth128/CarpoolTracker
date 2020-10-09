using CarpoolTracker.ViewModels.DriveDefinitions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarpoolTracker.Views.DriveDefinitions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DriveDefinitionsPage : ContentPage
    {
        private readonly DriveDefinitionsViewModel viewModel;

        public DriveDefinitionsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new DriveDefinitionsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
}