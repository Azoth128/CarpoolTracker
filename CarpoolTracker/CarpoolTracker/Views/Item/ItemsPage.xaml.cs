using CarpoolTracker.ViewModels;
using Xamarin.Forms;

namespace CarpoolTracker.Views
{
    public partial class ItemsPage : ContentPage
    {
        private readonly ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}