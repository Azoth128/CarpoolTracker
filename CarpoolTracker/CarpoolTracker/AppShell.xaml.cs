﻿using CarpoolTracker.Models;
using CarpoolTracker.Services;
using CarpoolTracker.Views;
using CarpoolTracker.Views.Calendar;
using CarpoolTracker.Views.DriveDefinitions;
using CarpoolTracker.Views.People;
using System.Linq;
using Xamarin.Forms;

namespace CarpoolTracker
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();

            RecreateCalendarPages();
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute(nameof(PeoplePage), typeof(PeoplePage));
            Routing.RegisterRoute(nameof(PersonEditPage), typeof(PersonEditPage));
            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
            Routing.RegisterRoute(nameof(DriveDefinitionsPage), typeof(DriveDefinitionsPage));
            Routing.RegisterRoute(nameof(DriveDefinitionEditPage), typeof(DriveDefinitionEditPage));
        }

        public void RecreateCalendarPages()
        {
            var oldContent = Flyout.Items.Where(section => !(section.CurrentItem.Content is CalendarPage)).ToList();

            Flyout.Items.Clear();

            //TODO: make sure in DataStore, that there is always a default definition
            var definitions = DependencyService.Get<IDataStore<DriveDefinition>>()
                .GetListAsync().Result
                .ToList();

            foreach (var definition in definitions)
            {
                var content = new ShellContent()
                {
                    Title = definition.Name,
                    Icon = ImageSource.FromFile("calendar_today.xml"),
                    Content = new CalendarPage(definition)
                };

                Flyout.Items.Add(content);
            }

            foreach (var shellContent in oldContent)
                Flyout.Items.Add(shellContent);
        }
    }
}