using System.ComponentModel;
using Xamarin.Forms;
using CarpoolTracker.ViewModels;

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