using CarpoolTracker.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarpoolTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonDetailPage : ContentPage
    {
        public PersonDetailPage()
        {
            InitializeComponent();

            BindingContext = new PersonDetailViewModel();
        }
    }
}