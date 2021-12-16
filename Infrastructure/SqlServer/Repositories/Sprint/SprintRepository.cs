using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.Sprint
{
    public partial class SprintRepository : ISprintRepository
    {
        private readonly IDomainFactory<Domain.Sprint> _sprintFactory = new SprintFactory();

        // Get requests
        public List<Domain.Sprint> GetAll()
        {
            var sprints = new List<Domain.Sprint>();

            var command = Database.GetCommand(ReqGetAll);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            // Add all sprints
            while(reader.Read()) sprints.Add(_sprintFactory.CreateFromSqlReader(reader));
            
            return sprints;
        }

        public List<Domain.Sprint> GetByIdProject(int idProject)
        {
            var sprints = new List<Domain.Sprint>();

            var command = Database.GetCommand(ReqGetByIdProject);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColIdProject, idProject);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            // Add all sprints
            while(reader.Read()) sprints.Add(_sprintFactory.CreateFromSqlReader(reader));
            
            return sprints;
        }

        public Domain.Sprint GetById(int id)
        {
            var command = Database.GetCommand(ReqGetById);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColId, id);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            // Return the sprint if found, null if not
            return reader.Read() ? _sprintFactory.CreateFromSqlReader(reader) : null;
        }

        // Post requests
        public Domain.Sprint Create(Domain.Sprint sprint)
        {
            var command = Database.GetCommand(ReqCreate);

            command.Parameters.AddWithValue("@" + ColIdProject, sprint.IdProject);
            command.Parameters.AddWithValue("@" + ColSprintNumber, sprint.SprintNumber);
            command.Parameters.AddWithValue("@" + ColDeadline, sprint.Deadline);
            command.Parameters.AddWithValue("@" + ColStartDate, sprint.StartDate);
            command.Parameters.AddWithValue("@" + ColDescription, sprint.Description);

            return new Domain.Sprint
            {
                Id = (int) command.ExecuteScalar(),
                SprintNumber = sprint.SprintNumber,
                IdProject = sprint.IdProject,
                Deadline = sprint.Deadline,
                StartDate = sprint.StartDate,
                Description = sprint.Description
            };
        }
        
        // Delete requests
        public bool Delete(int id)
        {
            var command = Database.GetCommand(ReqDeleteById);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColId, id);

            return command.ExecuteNonQuery() > 0;
        }
    }
}