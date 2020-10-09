using CarpoolTracker.Models;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CarpoolTracker.ViewModels.People
{
    public class PersonEditViewModel : EditViewModel<Person>
    {
        private System.Drawing.Color color;
        private bool firstColorChanged = false;
        private string name;
        private string surname;

        public PersonEditViewModel() : base()
        {
            Title = "Edit Person";
        }

        public Color Color { get => color; set => SetProperty(ref color, value); }
        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Surname { get => surname; set => SetProperty(ref surname, value); }

        protected override bool CanSave() => !(Name == null) || Name != "";

        protected async override void OnAfterSave() => await Shell.Current.Navigation.PopAsync();

        protected async override void OnCancel() => await Shell.Current.Navigation.PopAsync();

        protected override void OnItemLoaded(Person item)
        {
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