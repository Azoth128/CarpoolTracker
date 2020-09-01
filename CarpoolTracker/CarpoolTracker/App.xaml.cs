using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CarpoolTracker.Services;
using CarpoolTracker.Views;
using CarpoolTracker.Models;

namespace CarpoolTracker
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore<Item>>();
            DependencyService.Register<MockDataStore<Person>>();
            DependencyService.Register<MockDataStore<Track>>();
            DependencyService.Register<MockDataStore<Drive>>();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
