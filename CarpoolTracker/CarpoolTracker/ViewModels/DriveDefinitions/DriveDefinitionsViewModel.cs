using CarpoolTracker.Models;
using CarpoolTracker.Views.DriveDefinitions;
using Xamarin.Forms;

namespace CarpoolTracker.ViewModels.DriveDefinitions
{
    internal class DriveDefinitionsViewModel : ListViewModel<DriveDefinition>
    {
        public DriveDefinitionsViewModel() : base()
        {
            Title = "Drive Definitions";
        }

        protected override void OnItemTappedAsync(DriveDefinition item)
        {
            base.OnItemTappedAsync(item);
            Shell.Current.GoToAsync($"{nameof(DriveDefinitionEditPage)}?{nameof(DriveDefinitionEditViewModel.ItemId)}={item.Id}");
        }

        protected override void OnNewItem(object obj)
        {
            base.OnNewItem(obj);
            Shell.Current.GoToAsync($"{nameof(DriveDefinitionEditPage)}");
        }
    }
}