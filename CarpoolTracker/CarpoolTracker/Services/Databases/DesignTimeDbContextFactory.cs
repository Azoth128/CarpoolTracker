using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace CarpoolTracker.Services.Databases
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            Constants.DatabasePath = Directory.GetCurrentDirectory() + @"\Config.db";
            Debug.WriteLine(Constants.DatabasePath);
            return new DatabaseContext();
        }
    }
}