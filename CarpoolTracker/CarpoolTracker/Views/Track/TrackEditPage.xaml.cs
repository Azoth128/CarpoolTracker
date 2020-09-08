using CarpoolTracker.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarpoolTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrackEditPage : ContentPage
    {
        public TrackEditPage()
        {
            InitializeComponent();

            BindingContext = new TrackEditViewModel();
        }
    }
}