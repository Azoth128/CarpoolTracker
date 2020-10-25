using System;
using System.IO;

namespace CarpoolTracker.Services.Databases
{
    internal class Constants
    {
        public const string DatabaseFilename = "CarpoolTrackerSQLite.db3";

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
}