using System.Collections.Generic;
using System.Data;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.Technology
{
    public partial class TechnologyRepository : ITechnologyRepository
    {
        private readonly IDomainFactory<Domain.Technology> _technologyFactory = new TechnologyFactory();
        
        // Get requests
        public List<Domain.Technology> GetAll()
        {
            var technologies = new List<Domain.Technology>();

            var command = Database.GetCommand(ReqGetAll);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            // Add all projects
            while(reader.Read()) technologies.Add(_technologyFactory.CreateFromSqlReader(reader));

            return technologies;
        }

        public Domain.Technology GetById(int id)
        {
            var technologies = Database.GetCommand(ReqGetById);
            
            // Parametrize the command
            technologies.Parameters.AddWithValue("@" + ColId, id);

            var reader = technologies.ExecuteReader(CommandBehavior.CloseConnection);

            // Return the project if found, null if not
            return reader.Read() ? _technologyFactory.CreateFromSqlReader(reader) : null;
        }

        public Domain.Technology GetByName(string name)
        {
            var technologies = Database.GetCommand(ReqGetByName);
            
            // Parametrize the command
            technologies.Parameters.AddWithValue("@" + ColName, name);

            var reader = technologies.ExecuteReader(CommandBehavior.CloseConnection);

            // Return the project if found, null if not
            return reader.Read() ? _technologyFactory.CreateFromSqlReader(reader) : null;
        }
    }
}