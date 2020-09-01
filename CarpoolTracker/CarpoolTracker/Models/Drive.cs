using System;
using System.Collections.Generic;
using System.Text;

namespace CarpoolTracker.Models
{
    public class Drive
    {
        public string Id { get; set; }
        public Track Track { get; set; }
        public List<Person> People { get; set; }
    }
}
