using CarpoolTracker.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarpoolTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrackDetailPage : ContentPage
    {
        public TrackDetailPage()
        {
            InitializeComponent();

            BindingContext = new TrackDetailViewModel();
        }
    }
}