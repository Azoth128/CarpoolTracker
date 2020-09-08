using System;
using System.Collections.Generic;
using CarpoolTracker.ViewModels;
using CarpoolTracker.Views;
using Xamarin.Forms;

namespace CarpoolTracker
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(PersonDetailPage), typeof(PersonDetailPage));
            Routing.RegisterRoute(nameof(PersonEditPage), typeof(PersonEditPage));
            Routing.RegisterRoute(nameof(TrackDetailPage), typeof(TrackDetailPage));
            Routing.RegisterRoute(nameof(TrackEditPage), typeof(TrackEditPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
