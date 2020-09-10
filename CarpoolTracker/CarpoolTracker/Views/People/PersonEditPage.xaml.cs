using CarpoolTracker.ViewModels.People;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarpoolTracker.Views.People
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Nicht verwendete Parameter entfernen", Justification = "This is an Event and can't have other Parameters")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Nicht verwendete private Member entfernen", Justification = "Used in XAML")]
        private void ColorPicker_PickedColorChanged(object sender, Color e)
        {
            viewModel.ExecuteColorChangedCommand(e);
        }
    }
}