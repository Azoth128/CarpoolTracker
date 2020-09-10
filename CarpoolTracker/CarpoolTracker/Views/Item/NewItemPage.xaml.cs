using CarpoolTracker.Models;
using CarpoolTracker.ViewModels;
using Xamarin.Forms;

namespace CarpoolTracker.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}