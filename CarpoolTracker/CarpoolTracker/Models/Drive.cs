using CarpoolTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace CarpoolTracker.Models
{
    public class Drive : IDataModel, IHasTestValues<Drive>
    {
        public DateTime Date { get; set; }
        public DriveDefinition Definition { get; set; }
        public Person Driver { get; set; }
        public string Id { get; set; }

        public List<Drive> DefaultValues()
        {
            var driveDefinition = DependencyService.Get<IDataStore<DriveDefinition>>()
                                .GetListAsync()
                                .Result
                                .First();

            return new List<Drive>()
            {
                new Drive() {Id = Guid.NewGuid().ToString(), Date = DateTime.Today.AddDays(0), Definition = driveDefinition, Driver = driveDefinition.People[0]},
                new Drive() {Id = Guid.NewGuid().ToString(), Date = DateTime.Today.AddDays(1), Definition = driveDefinition, Driver = driveDefinition.People[1]}
            };
        }
    }
}