using CarpoolTracker.Helper;
using CarpoolTracker.Models;
using System;
using Xamarin.Forms;
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
            Selected = DateTime.Today;
        }

        public bool CanRemoveDriver { get => canRemoveDriver; set => SetProperty(ref canRemoveDriver, value); }
        public bool CanSetDriver { get => canSetDriver; set => SetProperty(ref canSetDriver, value); }

        public Command DayTappedCommand { get; }
        public EventCollection Events { get; }

        public DateTime Selected
        {
            get => selected;
            private set
            {
                selected = value;
                CanRemoveDriver = Events.ContainsKey(Selected);
            }
        }

        private void LoadEventList()
        {
            Events.Clear();
            foreach (var drive in DataStore.GetListAsync().Result)
            {
                if (Events.ContainsKey(drive.Date))
                {
                    ((DayEventCollection<Drive>)Events[drive.Date]).Add(drive);
                }
                else
                {
                    var color = drive.Driver.Color;
                    Events.Add(drive.Date, new DayEventCollection<Drive>(color, color.Lerp(System.Drawing.Color.Black, 0.35f), System.Drawing.Color.Black, System.Drawing.Color.White)
                    {
                        drive
                    });
                }
            }
        }

        public override void OnAppearing()
        {
            base.OnAppearing();
            LoadEventList();
        }
    }
}