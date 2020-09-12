using System.Collections.Generic;

namespace CarpoolTracker.Models
{
    public class DriveDefinition : IDataModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Person> People { get; set; }
        public Track Track { get; set; }
    }
}