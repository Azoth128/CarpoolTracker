using CarpoolTracker.Models;
using Xamarin.Forms;

namespace CarpoolTracker.ViewModels.DriveDefinitions
{
    internal class DriveDefinitionsViewModel : ListViewModel<DriveDefinition>
    {
        public DriveDefinitionsViewModel() : base()
        {
        }

        protected override void OnItemTappedAsync(DriveDefinition item)
        {
            base.OnItemTappedAsync(item);
            //Shell.Current.GoToAsync($"{nameof(DriveDefinition)}");
        }
    }
}