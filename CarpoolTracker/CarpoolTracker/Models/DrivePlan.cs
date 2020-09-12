using System;
using System.Collections.Generic;
using System.Text;

namespace CarpoolTracker.Models
{
    public class DrivePlan : IDataModel
    {
        public DriveDefinition DriveDefinition { get; set; }
        public string Id { get; set; }
        public bool IsActive { get; set; }
        //TODO: Days, when the Plan is active
    }
}