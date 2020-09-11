using CarpoolTracker.Models;
using CarpoolTracker.Views.People;
using System;
using Xamarin.Forms;

namespace CarpoolTracker.ViewModels.People
{
    public class PersonDetailViewModel : DetailViewModel<Person>
    {
        private Color color;
        private string name;
        private string surname;

        public PersonDetailViewModel()
        {
            EditPersonCommand = new Command(ExecuteEditPersonCommand);
        }

        public Color Color { get => color; set => SetProperty(ref color, value); }
        public Command EditPersonCommand { get; set; }
        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Surname { get => surname; set => SetProperty(ref surname, value); }

        private async void ExecuteEditPersonCommand(object obj)
        {
            await Shell.Current.GoToAsync($"{nameof(PersonEditPage)}?{nameof(ItemId)}={ItemId}");
        }

        protected override void OnItemLoaded(Person item)
        {
            Name = item.Name;
            Surname = item.Surname;
            Color = item.Color;
        }
    }
}