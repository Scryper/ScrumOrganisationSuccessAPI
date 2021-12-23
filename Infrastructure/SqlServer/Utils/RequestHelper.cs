using System.Collections.Generic;
using System.Data;

namespace Infrastructure.SqlServer.Utils
{
    // This class allows to factor a bit more, the list are generic and the factory too
    // The request helper allows every type of factories which allows to create every type of objects
    public class RequestHelper<T>
    {
        // Utils for GetById...
        // All return a list of objects, the only changing parameters are the request and the column on which 
        // the request base its verification
        public List<T> GetByIdHelper(int id, string column, string request, IDomainFactory<T> factory)
        {
            var list = new List<T>();

            var command = Database.GetCommand(request);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + column, id);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            // Add all meetings
            while(reader.Read()) list.Add(factory.CreateFromSqlReader(reader));

            return list;
        }
    }
}