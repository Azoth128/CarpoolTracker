using CarpoolTracker.Models;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace CarpoolTracker.ViewModels.DriveDefinitions
{
    internal class DriveDefinitionEditViewModel : EditViewModel<DriveDefinition>
    {
        private string name;

        public DriveDefinitionEditViewModel() : base()
        {
            Title = "Create Drive Definition";

            PropertyChangedEventHandler _event = null;
            _event = (object sender, PropertyChangedEventArgs e) =>
            {
                if (e.PropertyName == "Name")
                {
                    Title = "Edit Drive Definition";
                    PropertyChanged -= _event;
                }
            };
            PropertyChanged += _event;
        }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public List<Person> People { get; }

        public string PeopleString
        {
            get
            {
                return "";
            }
        }

        protected override bool CanSave()
        {
            return true;
        }

        protected override void OnAfterSave()
        {
            Shell.Current.Navigation.PopAsync();
            if (Shell.Current is AppShell shell)
                shell.RecreateCalendarPages();
        }

        protected override void OnCancel()
        {
            Shell.Current.Navigation.PopAsync();
        }

        protected override void OnItemLoaded(DriveDefinition item)
        {
            Name = item.Name;
        }

        protected override void OnSave(DriveDefinition item)
        {
            item.Name = Name;
        }
    }
}