using System.Data.SqlClient;
using System.IO;

namespace Infrastructure.SqlServer.System
{
    public class DatabaseManager : IDatabaseManager
    {
        private void ExecuteScript(string file)
        {
            // Get the path of the Init.sql file. Allows to use it from different PCs
            var rawPath = Directory.GetCurrentDirectory();
            rawPath = rawPath.Replace("WebAPI", "");
            var path = Path.Combine(rawPath + "\\Infrastructure\\SqlServer\\Resources\\" + file);
            var script = File.ReadAllText(path); // Get the script

            // Connect to database
            var connection = Database.GetConnection();
            connection.Open();
            var command = new SqlCommand
            { // Command's settings
                Connection = connection, // On which database we are working
                CommandText = script // What will we do
            };

            command.ExecuteNonQuery(); // Execute the command
        }
        
        public void CreateDatabaseAndTables()
        {
            ExecuteScript("Init.sql");
        }

        public void FillTables()
        {
            ExecuteScript("Data.sql");
        }
    }
}