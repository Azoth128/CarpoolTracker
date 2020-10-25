using CarpoolTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace CarpoolTracker.Models
{
    public class DriveDefinition : IDataModel, IHasTestValues<DriveDefinition>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public List<Person> People { get; set; }

        public List<DriveDefinition> DefaultValues()
        {
            var people = DependencyService.Get<IDataStore<Person>>()
                    .GetListAsync()
                    .Result
                    .ToList();

            return new List<DriveDefinition>()
            {
                new DriveDefinition() { Id = Guid.NewGuid(), Name = "Work", People = people },
                new DriveDefinition() { Id = Guid.NewGuid(), Name = "School", People = people }
            };
        }
    }
}