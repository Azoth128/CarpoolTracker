using CarpoolTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace CarpoolTracker.ViewModels.Calendar
{
    internal class SelectPersonPopupViewModel : BaseViewModel<Person>
    {
        private readonly DriveDefinition driveDefinition;
        private readonly Action<Person> personSelected;
        private Person selectedPerson;

        public SelectPersonPopupViewModel(Action<Person> personSelected, DriveDefinition driveDefinition)
        {
            this.personSelected = personSelected;
            this.driveDefinition = driveDefinition ?? throw new ArgumentNullException();

            People = this.driveDefinition.People.ToList();
            SelectedPerson = null;
        }

        public ICollection<Person> People { get; }

        public Person SelectedPerson
        {
            get => selectedPerson;
            set
            {
                SetProperty(ref selectedPerson, value);
                if (value != null)
                    CloseAndReturnResult();
            }
        }

        private void CloseAndReturnResult()
        {
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
            personSelected?.Invoke(SelectedPerson);
        }
    }
}