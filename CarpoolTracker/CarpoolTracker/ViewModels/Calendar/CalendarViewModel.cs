using CarpoolTracker.Helper;
using CarpoolTracker.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Plugin.Calendar.Interfaces;
using Xamarin.Plugin.Calendar.Models;

namespace CarpoolTracker.ViewModels.Calendar
{
    public class CalendarViewModel : BaseViewModel<Drive>
    {
        private bool canRemoveDriver = false;
        private bool canSetDriver = true;
        private DateTime selected;

        public CalendarViewModel()
        {
            Title = "Calendar";

            Events = new EventCollection();
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

        private void CheckCanRemoveDriver() => CanRemoveDriver = Events.ContainsKey(Selected);

        public Command SetDriverCommand { get; }

        private void LoadEventList()
        {
            Events.Clear();
            foreach (var drive in DataStore.GetListAsync().Result)
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

        private async void OnRemoveDriver(object obj)
        {
            var drives = await DataStore.GetListAsync();
            drives.ToList().ForEach(async drive =>
            {
                if (drive.Date.Date == Selected.Date)
                    await DataStore.DeleteAsync(drive.Id);
            });
            LoadEventList();
            CheckCanRemoveDriver();
        }

        private void OnSetDiver(object obj)
        {
            throw new NotImplementedException();
        }

        public override void OnAppearing()
        {
            base.OnAppearing();
            LoadEventList();
        }
    }
}