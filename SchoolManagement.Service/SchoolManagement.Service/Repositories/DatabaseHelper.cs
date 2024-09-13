using LiteDB;
using System.IO;

namespace SchoolManagement.Service.Repositories
{
    public static class DatabaseHelper
    {
        // Define the path for the database file.
        private static readonly string _databaseFile = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "App_Data", "SchoolManagement.db");

        public static LiteDatabase GetDatabase()
        {
            // Ensure the directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(_databaseFile));

            // Return a LiteDatabase instance with the specified path
            return new LiteDatabase($"Filename={_databaseFile};Connection=shared");
        }

        public static string GetDatabasePath()
        {
            return _databaseFile;
        }
    }
}
