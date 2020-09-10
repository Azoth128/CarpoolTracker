using CarpoolTracker.Models;
using System;
using Xamarin.Forms;

namespace CarpoolTracker.ViewModels.People
{
    [Xamarin.Forms.QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class PersonEditViewModel : EditViewModel<Person>
    {
        private System.Drawing.Color color;
        private bool firstColorChanged = false;
        private string name;
        private string surname;

        public PersonEditViewModel()
        {
            Title = "Person";
        }

        public Color Color { get => color; set => SetProperty(ref color, value); }
        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Surname { get => surname; set => SetProperty(ref surname, value); }

        protected override bool CanSave(object arg)
        {
            return !(Name == null) || Name != "";
        }

        protected async override void OnAfterSave()
        {
            if (IsInsert)
                await Shell.Current.GoToAsync($"..");
            else
                await Shell.Current.GoToAsync($"..?{nameof(PersonDetailViewModel.PersonId)}={ItemId}");
        }

        protected async override void OnCancel(object obj)
        {
            if (IsInsert)
                await Shell.Current.GoToAsync($"..");
            else
                await Shell.Current.GoToAsync($"..?{nameof(PersonDetailViewModel.PersonId)}={ItemId}");
        }

        protected override void OnItemLoaded(Person item)
        {
            base.OnItemLoaded(item);

            Name = item.Name;
            Surname = item.Surname;
            Color = item.Color;
        }

        protected override void OnSave(Person item)
        {
            item.Name = Name;
            item.Surname = Surname;
            item.Color = Color;
        }

        public void ExecuteColorChangedCommand(Color e)
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