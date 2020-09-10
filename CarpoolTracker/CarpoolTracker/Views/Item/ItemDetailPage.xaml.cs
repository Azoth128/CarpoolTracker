using CarpoolTracker.ViewModels;
using Xamarin.Forms;

namespace CarpoolTracker.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}