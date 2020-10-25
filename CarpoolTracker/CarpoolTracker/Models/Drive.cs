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
        public Guid Id { get; set; }

        public List<Drive> DefaultValues()
        {
            var driveDefinition = DependencyService.Get<IDataStore<DriveDefinition>>()
                                .GetListAsync()
                                .Result
                                .First();

            return new List<Drive>()
            {
                new Drive() {Id = Guid.NewGuid(), Date = DateTime.Today.AddDays(0), Definition = driveDefinition, Driver = driveDefinition.People[0]},
                new Drive() {Id = Guid.NewGuid(), Date = DateTime.Today.AddDays(1), Definition = driveDefinition, Driver = driveDefinition.People[0]},
                new Drive() {Id = Guid.NewGuid(), Date = DateTime.Today.AddDays(2), Definition = driveDefinition, Driver = driveDefinition.People[0]},
                new Drive() {Id = Guid.NewGuid(), Date = DateTime.Today.AddDays(3), Definition = driveDefinition, Driver = driveDefinition.People[0]},
                new Drive() {Id = Guid.NewGuid(), Date = DateTime.Today.AddDays(4), Definition = driveDefinition, Driver = driveDefinition.People[0]},
                new Drive() {Id = Guid.NewGuid(), Date = DateTime.Today.AddDays(5), Definition = driveDefinition, Driver = driveDefinition.People[1]},
                new Drive() {Id = Guid.NewGuid(), Date = DateTime.Today.AddDays(6), Definition = driveDefinition, Driver = driveDefinition.People[1]},
                new Drive() {Id = Guid.NewGuid(), Date = DateTime.Today.AddDays(7), Definition = driveDefinition, Driver = driveDefinition.People[1]},
                new Drive() {Id = Guid.NewGuid(), Date = DateTime.Today.AddDays(8), Definition = driveDefinition, Driver = driveDefinition.People[1]},
                new Drive() {Id = Guid.NewGuid(), Date = DateTime.Today.AddDays(9), Definition = driveDefinition, Driver = driveDefinition.People[1]}
            };
        }
    }
}