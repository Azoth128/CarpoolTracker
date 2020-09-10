using CarpoolTracker.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarpoolTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonEditPage : ContentPage
    {
        private readonly PersonEditViewModel viewModel;

        public PersonEditPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new PersonEditViewModel();
        }

        private void ColorPicker_PickedColorChanged(object sender, Color e)
        {
            viewModel.ExecuteColorChangedCommand(sender, e);
        }
    }
}