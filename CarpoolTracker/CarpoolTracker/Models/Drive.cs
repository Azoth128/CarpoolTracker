using System;
using System.Collections.Generic;

namespace CarpoolTracker.Models
{
    public class Drive : IDataModel
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public Track Track { get; set; }
        public List<Person> People { get; set; }
    }
}