using CarpoolTracker.Views.People;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace CarpoolTracker.ViewModels
{
    public class SettingItem
    {
        public SettingItem(string caption, string image, string route)
        {
            Caption = caption;
            Image = image;
            Route = route;
        }

        public string Caption { get; set; }
        public string Image { get; set; }
        public string Route { get; set; }
    }

    public class SettingsViewModel : BaseViewModel<object>
    {
        private SettingItem selected;

        public SettingsViewModel() : base()
        {
            Title = "Settings";

            Items = new ObservableCollection<SettingItem>()
            {
                new SettingItem("Drive Definitions", "settings.xml", ""),
                new SettingItem("People", "people.xml", $"{nameof(PeoplePage)}"),
                new SettingItem("Data Saving Settings", "settings.xml", ""),
                new SettingItem("copyright notice", "settings.xml", ""),
                new SettingItem("note of thanks", "settings.xml", "")
            };
        }

        public ObservableCollection<SettingItem> Items { get; }

        public SettingItem Selected
        {
            get => selected;
            set
            {
                SetProperty(ref selected, value);
                if (value != null && value.Route.Length > 0)
                {
                    Shell.Current.GoToAsync(value.Route);
                }
            }
        }
    }
}