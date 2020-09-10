using System;
using System.Collections.Generic;

namespace CarpoolTracker.Models
{
    public class Drive : IDataModel
    {
        public DateTime Date { get; set; }
        public string Id { get; set; }
        public List<Person> People { get; set; }
        public Track Track { get; set; }
    }
}