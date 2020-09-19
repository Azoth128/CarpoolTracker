using CarpoolTracker.Models;
using CarpoolTracker.ViewModels.Calendar;
using Rg.Plugins.Popup.Pages;
using System;
using Xamarin.Forms.Xaml;

namespace CarpoolTracker.Views.Calendar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectPersonPopupPage : PopupPage
    {
        private readonly SelectPersonPopupViewModel viewModel;

        public SelectPersonPopupPage(Action<Person> personSelected, DriveDefinition driveDefinition)
        {
            InitializeComponent();

            BindingContext = viewModel = new SelectPersonPopupViewModel(personSelected, driveDefinition);

            var itemHeight = 60;
            CollectionView.HeightRequest = viewModel.People.Count * itemHeight + 5;
        }
    }
}