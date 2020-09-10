using CarpoolTracker.Models;
using CarpoolTracker.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CarpoolTracker.ViewModels
{
    public class PeoplesViewModel : BaseViewModel<Person>
    {
        public PeoplesViewModel()
        {
            Title = "People";
            Items = new ObservableCollection<Person>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTappedCommand = new Command<Person>(ExecuteItemTappedCommand);
            NewCommand = new Command(ExecuteNewCommand);
        }

        public ObservableCollection<Person> Items { get; }

        public Command<Person> ItemTappedCommand { get; }
        public Command LoadItemsCommand { get; }
        public Command NewCommand { get; }

        private async void ExecuteItemTappedCommand(Person person)
        {
            await Shell.Current.GoToAsync($"{nameof(PersonDetailPage)}?{nameof(PersonDetailViewModel.PersonId)}={person.Id}");
        }

        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetListAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void ExecuteNewCommand(object obj)
        {
            await Shell.Current.GoToAsync($"{nameof(PersonEditPage)}");
        }

        private void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            //await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            //((ListView)sender).SelectedItem = null;
        }

        public async void OnAppearing()
        {
            await ExecuteLoadItemsCommand();
        }
    }
}