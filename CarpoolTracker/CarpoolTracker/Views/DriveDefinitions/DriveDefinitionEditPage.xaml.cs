using CarpoolTracker.ViewModels.DriveDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarpoolTracker.Views.DriveDefinitions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DriveDefinitionEditPage : ContentPage
    {
        private readonly DriveDefinitionEditViewModel viewModel;

        public DriveDefinitionEditPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new DriveDefinitionEditViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
}