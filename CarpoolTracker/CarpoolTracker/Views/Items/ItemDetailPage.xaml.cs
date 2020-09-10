using CarpoolTracker.ViewModels.Items;
using Xamarin.Forms;

namespace CarpoolTracker.Views.Items
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