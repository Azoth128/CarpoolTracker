using CarpoolTracker.Models;
using Xamarin.Forms;

namespace CarpoolTracker.ViewModels
{
    [Xamarin.Forms.QueryProperty(nameof(PersonId), nameof(PersonId))]
    public class PersonEditViewModel : BaseViewModel<Person>
    {
        private string personId;
        private bool firstColorChanged = false;

        private string name;
        private string surname;
        private System.Drawing.Color color;

        public string Name { get => name; set => SetProperty(ref name, value); }
        public string Surname { get => surname; set => SetProperty(ref surname, value); }
        public Color Color { get => color; set => SetProperty(ref color, value); }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }


        public PersonEditViewModel()
        {
            
            SaveCommand = new Command(OnSave, CanSave);
            CancelCommand = new Command(OnCancel);
            PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();
        }

        private async void OnCancel(object obj)
        {
            await Shell.Current.GoToAsync($"..?{nameof(PersonDetailViewModel.PersonId)}={PersonId}");
        }

        private bool CanSave(object arg)
        {
            return !(Name == null) || Name != "";
        }

        private async void OnSave(object obj)
        {
            var person = await DataStore.GetAsync(PersonId);
            person.Name = Name;
            person.Surname = Surname;
            person.Color = Color;
            await DataStore.UpdateAsync(person);

            await Shell.Current.GoToAsync($"..?{nameof(PersonDetailViewModel.PersonId)}={PersonId}");
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

        public string PersonId
        {
            get => personId;
            set
            {
                personId = value;
                LoadItem();
            }
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