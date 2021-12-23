using System.Collections.Generic;
using System.Data;

namespace Infrastructure.SqlServer.Utils
{
    // This class allows to factor a bit more, the list are generic and the factory too
    // The request helper allows every type of factories which allows to create every type of objects
    // All return a list of objects, or an object, the only changing parameters are the request and the column on which 
    // the request base its verification
    public class RequestHelper<T>
    {
        // GetAll() helper
        public List<T> GetAll(string request, IDomainFactory<T> factory)
        {
            var list = new List<T>();
            
            var command = Database.GetCommand(request);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            // Add all comments
            while(reader.Read()) list.Add(factory.CreateFromSqlReader(reader));

            return list;
        }
        
        // GetById... helper -> for lists
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
        
        // GetById helper -> for objects alone
        public T GetById(int id, string column, string request, IDomainFactory<T> factory)
        {
            var command = Database.GetCommand(request);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + column, id);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            // Return the comment if found, null if not
            return reader.Read() ? factory.CreateFromSqlReader(reader) : default;
        }
        
        // GetByName() helper
        public T GetByName(string name, string column, string request, IDomainFactory<T> factory)
        {
            var command = Database.GetCommand(request);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + column, name);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            // Return the project if found, null if not
            return reader.Read() ? factory.CreateFromSqlReader(reader) : default;
        }
    }
}