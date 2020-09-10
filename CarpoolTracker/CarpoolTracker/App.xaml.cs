using CarpoolTracker.Models;
using CarpoolTracker.Services;
using Xamarin.Forms;

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