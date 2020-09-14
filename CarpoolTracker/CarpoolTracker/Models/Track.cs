using System;
using System.Collections.Generic;

namespace CarpoolTracker.Models
{
    public class Track : IDataModel, IHasTestValues<Track>
    {
        public int Distance { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }

        public List<Track> DefaultValues()
        {
            return new List<Track>()
            {
                new Track() {Id = Guid.NewGuid().ToString(), Name = "Work", Distance = 42}
            };
        }
    }
}