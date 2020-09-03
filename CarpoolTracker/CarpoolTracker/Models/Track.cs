using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace CarpoolTracker.Models
{
    public class Track : IDataModel, IHasDefaults<Track>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Distance { get; set; }

        public List<Track> DefaultValues()
        {
            return new List<Track>()
            {
                new Track() {Id = Guid.NewGuid().ToString(), Name = "Work", Distance = 42}
            };
        }
    }
}
