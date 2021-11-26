using System.Data.SqlClient;

namespace Infrastructure.SqlServer
{
    public class Database
    {
        private const string ConnectionString = "Server=LAPTOP-T5LUSKJ3;Database=db_scrum_organisation_success;Integrated Security=SSPI";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
        
        // Create a SqlCommand with the right request
        public static SqlCommand GetCommand(string request)
        {
            var connection = GetConnection();
            connection.Open();

            return new SqlCommand
            {
                Connection = connection,
                CommandText = request
            };
        }
    }
}