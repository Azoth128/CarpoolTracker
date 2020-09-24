using CarpoolTracker.Helper;
using CarpoolTracker.Models;
using CarpoolTracker.Services;
using CarpoolTracker.Views.Calendar;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Plugin.Calendar.Models;

namespace CarpoolTracker.ViewModels.Calendar
{
    public class CalendarViewModel : BaseViewModel<Drive>
    {
        private readonly DriveDefinition driveDefinition;
        private bool canRemoveDriver = false;
        private bool canSetDriver = true;
        private List<Drive> driveList;
        private DateTime selected;

        public CalendarViewModel(/*DriveDefinition driveDefinition*/)
        {
            //driveDefinition = driveDefinition ?? throw new ArgumentNullException();
            //TODO: change to Constructor-Parameter
            driveDefinition = DependencyService.Get<IDataStore<DriveDefinition>>()
                .GetListAsync().Result
                .FirstOrDefault() ?? throw new ArgumentNullException();

            Title = "Calendar";

            Events = new EventCollection();
            Refresh();
            LoadEventList();

            DayTappedCommand = new Command<DateTime>(date => Selected = date);
            RemoveDriverCommand = new Command(OnRemoveDriver);
            SetDriverCommand = new Command(OnSetDiver);
            Selected = DateTime.Today;
        }

        public bool CanRemoveDriver { get => canRemoveDriver; set => SetProperty(ref canRemoveDriver, value); }

        public bool CanSetDriver { get => canSetDriver; set => SetProperty(ref canSetDriver, value); }

        public Command DayTappedCommand { get; }

        public EventCollection Events { get; }

        public Command RemoveDriverCommand { get; }

        public DateTime Selected
        {
            get => selected;
            private set
            {
                selected = value;
                CheckCanRemoveDriver();
            }
        }

        public Command SetDriverCommand { get; }

        private void CheckCanRemoveDriver() => CanRemoveDriver = Events.ContainsKey(Selected);

        private async void DriverSet(Person person)
        {
            if (person is null)
                throw new ArgumentNullException();

            driveList.ForEach(async drive =>
            {
                if (drive.Definition == driveDefinition && drive.Date.Date == selected.Date)
                    await DataStore.DeleteAsync(drive.Id);
            });

            await DataStore.AddAsync(new Drive()
            {
                Id = Guid.NewGuid().ToString(),
                Date = selected,
                Definition = driveDefinition,
                Driver = person
            });
            Refresh();
            LoadEventList();
            CheckCanRemoveDriver();
        }

        private void LoadEventList()
        {
            Events.Clear();
            foreach (var drive in driveList.Where(drive => drive.Definition == driveDefinition))
            {
                var color = drive.Driver.Color;
                Events.Add(drive.Date, new DriveEvent(
                    drive,
                    color,
                    color.Lerp(System.Drawing.Color.Black, 0.35f),
                    System.Drawing.Color.Black,
                    System.Drawing.Color.White));
            }
        }

        private void OnRemoveDriver(object obj)
        {
            driveList.ForEach(async drive =>
            {
                if (drive.Definition == driveDefinition && drive.Date.Date == Selected.Date)
                    await DataStore.DeleteAsync(drive.Id);
            });
            Refresh();
            LoadEventList();
            CheckCanRemoveDriver();
        }

        private void OnSetDiver(object obj)
        {
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new SelectPersonPopupPage(DriverSet, driveDefinition));
        }

        private void Refresh()
        {
            driveList = DataStore.GetListAsync().Result.ToList();
        }

        public override void OnAppearing()
        {
            base.OnAppearing();
            LoadEventList();
        }
    }
}