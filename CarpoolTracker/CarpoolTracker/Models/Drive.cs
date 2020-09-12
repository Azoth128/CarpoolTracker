using System;

namespace CarpoolTracker.Models
{
    public class Drive : IDataModel
    {
        public DateTime Date { get; set; }
        public DriveDefinition Definition { get; set; }
        public Person Driver { get; set; }
        public string Id { get; set; }
    }
}