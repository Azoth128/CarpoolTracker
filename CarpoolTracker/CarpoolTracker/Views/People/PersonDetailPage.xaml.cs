using CarpoolTracker.ViewModels.People;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarpoolTracker.Views.People
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonDetailPage : ContentPage
    {
        private readonly PersonDetailViewModel viewModel;

        public PersonDetailPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new PersonDetailViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
}