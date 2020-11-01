using CarpoolTracker.Migrations;
using CarpoolTracker.Models;
using CarpoolTracker.Services;
using CarpoolTracker.Services.Databases;
using Xamarin.Forms;

namespace CarpoolTracker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var db = new DatabaseContext();
            DependencyService.RegisterSingleton<IDataStore<Person>>(new EfDataStoreConnector<Person>(db.People, db));
            DependencyService.RegisterSingleton<IDataStore<Drive>>(new EfDataStoreConnector<Drive>(db.Drives, db));
            DependencyService.RegisterSingleton<IDataStore<DriveDefinition>>(new EfDataStoreConnector<DriveDefinition>(db.DriveDefinitions, db));
            DependencyService.RegisterSingleton<IDataStore<DrivePlan>>(new EfDataStoreConnector<DrivePlan>(db.DrivePlans, db));

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