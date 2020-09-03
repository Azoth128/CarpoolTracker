using CarpoolTracker.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarpoolTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PeoplesPage : ContentPage
    {
        private readonly PeoplesViewModel viewModel;

        public PeoplesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new PeoplesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
}
