using CarpoolTracker.ViewModels.People;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarpoolTracker.Views.People
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PeoplePage : ContentPage
    {
        private readonly PeopleViewModel viewModel;

        public PeoplePage()
        {
            InitializeComponent();

            BindingContext = viewModel = new PeopleViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
}