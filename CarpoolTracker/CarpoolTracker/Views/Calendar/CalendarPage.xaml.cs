using CarpoolTracker.Models;
using CarpoolTracker.ViewModels.Calendar;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarpoolTracker.Views.Calendar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarPage : ContentPage
    {
        private readonly CalendarViewModel viewModel;

        public CalendarPage(DriveDefinition driveDefinition)
        {
            InitializeComponent();

            BindingContext = viewModel = new CalendarViewModel(driveDefinition);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
}