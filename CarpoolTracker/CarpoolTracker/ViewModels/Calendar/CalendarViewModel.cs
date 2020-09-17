using CarpoolTracker.Helper;
using CarpoolTracker.Models;
using System.Drawing;
using Xamarin.Plugin.Calendar.Models;

namespace CarpoolTracker.ViewModels.Calendar
{
    public class CalendarViewModel : BaseViewModel<Drive>
    {
        public CalendarViewModel()
        {
            Title = "Calendar";

            Events = new EventCollection();
            LoadEventList();
        }

        public EventCollection Events { get; set; }

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
                    Events.Add(drive.Date, new DayEventCollection<Drive>(color, color.Lerp(Color.Black, 0.35f), Color.Black, Color.White)
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