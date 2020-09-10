using CarpoolTracker.Models;
using CarpoolTracker.Views.People;
using Xamarin.Forms;

namespace CarpoolTracker.ViewModels.People
{
    public class PeopleViewModel : ListViewModel<Person>
    {
        public PeopleViewModel()
        {
            Title = "People";
        }

        protected override async void OnItemTappedAsync(Person item)
        {
            base.OnItemTappedAsync(item);
            await Shell.Current.GoToAsync($"{nameof(PersonDetailPage)}?{nameof(PersonDetailViewModel.PersonId)}={item.Id}");
        }

        protected override async void OnNewItem(object obj)
        {
            base.OnNewItem(obj);
            await Shell.Current.GoToAsync($"{nameof(PersonEditPage)}");
        }
    }
}