using CarpoolTracker.Models;
using System;
using Xamarin.Forms;

namespace CarpoolTracker.ViewModels
{
    [Xamarin.Forms.QueryProperty(nameof(PersonId), nameof(PersonId))]
    public class PersonEditViewModel : BaseViewModel<Person>
    {
        private System.Drawing.Color color;
        private bool firstColorChanged = false;
        private string name;
        private string personId;
        private string surname;

        public PersonEditViewModel()
        {
            SaveCommand = new Command(OnSave, CanSave);
            CancelCommand = new Command(OnCancel);
            PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool IsInsert { get => PersonId == null || PersonId == ""; }
        public Command CancelCommand { get; }
        public Color Color { get => color; set => SetProperty(ref color, value); }
        public string Name { get => name; set => SetProperty(ref name, value); }

        public string PersonId
        {
            get => personId;
            set
            {
                personId = value;
                LoadItem();
            }
        }

        public Command SaveCommand { get; }
        public string Surname { get => surname; set => SetProperty(ref surname, value); }

        private bool CanSave(object arg)
        {
            return !(Name == null) || Name != "";
        }

        private async void LoadItem()
        {
            var person = await DataStore.GetAsync(personId);

            Name = person.Name;
            Surname = person.Surname;
            Color = person.Color;
        }

        private async void OnCancel(object obj)
        {
            if (IsInsert)
                await Shell.Current.GoToAsync($"..");
            else
                await Shell.Current.GoToAsync($"..?{nameof(PersonDetailViewModel.PersonId)}={PersonId}");
        }

        private async void OnSave(object obj)
        {
            Person person;
            if (IsInsert)
                person = new Person() { Id = Guid.NewGuid().ToString() };
            else
                person = await DataStore.GetAsync(PersonId);

            person.Name = Name;
            person.Surname = Surname;
            person.Color = Color;

            if (IsInsert)
            {
                await DataStore.AddAsync(person);
                await Shell.Current.GoToAsync($"..");
            }
            else
            {
                await DataStore.UpdateAsync(person);
                await Shell.Current.GoToAsync($"..?{nameof(PersonDetailViewModel.PersonId)}={PersonId}");
            }
        }

        public void ExecuteColorChangedCommand(object sender, Color e)
        {
            if (!firstColorChanged)
            {
                firstColorChanged = true;
                return;
            }
            Color = e;
        }
    }
}