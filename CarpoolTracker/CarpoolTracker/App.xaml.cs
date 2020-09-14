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

            DependencyService.Register<MockDataStore<Person>>();
            DependencyService.Register<MockDataStore<Track>>();
            DependencyService.Register<MockDataStore<Drive>>();
            DependencyService.Register<MockDataStore<DriveDefinition>>();
            DependencyService.Register<MockDataStore<DrivePlan>>();

            MainPage = new AppShell();
        }

        protected override void OnResume()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnStart()
        {
        }
    }
}