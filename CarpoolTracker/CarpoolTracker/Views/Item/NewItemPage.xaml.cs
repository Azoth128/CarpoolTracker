using CarpoolTracker.Models;
using CarpoolTracker.ViewModels;
using Xamarin.Forms;

namespace CarpoolTracker.Views
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