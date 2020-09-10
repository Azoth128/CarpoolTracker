using CarpoolTracker.Models;
using CarpoolTracker.Views;
using Xamarin.Forms;

namespace CarpoolTracker.ViewModels
{
    [QueryProperty(nameof(PersonId), nameof(PersonId))]
    public class PersonDetailViewModel : BaseViewModel<Person>
    {
        private Color color;
        private string name;
        private string personId;
        private string surname;

        public PersonDetailViewModel()
        {
            EditPersonCommand = new Command(ExecuteEditPersonCommand);
        }

        public Color Color { get => color; set => SetProperty(ref color, value); }
        public Command EditPersonCommand { get; set; }
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

        public string Surname { get => surname; set => SetProperty(ref surname, value); }

        private async void ExecuteEditPersonCommand(object obj)
        {
            await Shell.Current.GoToAsync($"{nameof(PersonEditPage)}?{nameof(PersonEditViewModel.PersonId)}={personId}");
        }

        private async void LoadItem()
        {
            var person = await DataStore.GetAsync(personId);

            Name = person.Name;
            Surname = person.Surname;
            Color = person.Color;
        }
    }
}