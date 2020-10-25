using System;

namespace CarpoolTracker.Models
{
    public class DrivePlan : IDataModel
    {
        public DriveDefinition DriveDefinition { get; set; }
        public Guid Id { get; set; }

        public bool IsActive { get; set; }
        //TODO: Days, when the Plan is active
    }
}