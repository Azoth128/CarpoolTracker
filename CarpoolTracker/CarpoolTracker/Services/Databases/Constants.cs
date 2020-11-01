using System;
using System.IO;

namespace CarpoolTracker.Services.Databases
{
    internal class Constants
    {
        private static string databasePath = "";
        public const string DatabaseFilename = "CarpoolTrackerSQLite.db3";

        public static string DatabasePath
        {
            set
            {
                databasePath = value ?? "";
            }
            get
            {
                if (databasePath.Length == 0)
                {
                    var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    databasePath = Path.Combine(basePath, DatabaseFilename);
                }

                return databasePath;
            }
        }
    }
}