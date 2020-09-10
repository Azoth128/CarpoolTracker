using CarpoolTracker.Models;
using CarpoolTracker.ViewModels.Items;
using Xamarin.Forms;

namespace CarpoolTracker.Views.Items
{
    public partial class NewItemPage : ContentPage
    {
        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }

        public Item Item { get; set; }
    }
}