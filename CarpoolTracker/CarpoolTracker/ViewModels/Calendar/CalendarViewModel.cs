using CarpoolTracker.Models;
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
                    Events.Add(drive.Date, new DayEventCollection<Drive>(drive.Driver.Color, null)
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