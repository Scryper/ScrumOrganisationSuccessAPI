using System.Data.SqlClient;

namespace Infrastructure.SqlServer
{
    public class Database
    {
        // change server name with your own server name on ssms
        private const string ConnectionString = "Server=LAPTOP-T5LUSKJ3;Database=db_scrum_organisation_success;Integrated Security=SSPI; Pooling=false";
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