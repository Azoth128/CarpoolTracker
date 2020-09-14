using CarpoolTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace CarpoolTracker.Models
{
    public class DriveDefinition : IDataModel, IHasTestValues<DriveDefinition>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Person> People { get; set; }
        public Track Track { get; set; }

        public List<DriveDefinition> DefaultValues()
        {
            var tracks = DependencyService.Get<IDataStore<Track>>()
                    .GetListAsync()
                    .Result
                    .ToList();

            var people = DependencyService.Get<IDataStore<Person>>()
                    .GetListAsync()
                    .Result
                    .ToList();

            return new List<DriveDefinition>()
            {
                new DriveDefinition() { Id = Guid.NewGuid().ToString(), Name = "Work", Track = tracks.Find(track => track.Name == "Work"), People = people }
            };
        }
    }
}