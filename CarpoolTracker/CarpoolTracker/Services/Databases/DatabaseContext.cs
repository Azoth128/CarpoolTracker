using CarpoolTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace CarpoolTracker.Services.Databases
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
            SQLitePCL.Batteries_V2.Init();
            Database.Migrate();
        }

        public DbSet<DriveDefinition> DriveDefinitions { get; set; }
        public DbSet<DrivePlan> DrivePlans { get; set; }
        public DbSet<Drive> Drives { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={Constants.DatabasePath}");
        }
    }
}