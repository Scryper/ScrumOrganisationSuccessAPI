using System.Collections.Generic;
using System.Data;
using Infrastructure.SqlServer.Utils;
using NotImplementedException = System.NotImplementedException;

namespace Infrastructure.SqlServer.Repositories.Project
{
    public partial class ProjectRepository : IProjectRepository
    {
        private readonly IDomainFactory<Domain.Project> _projectFactory = new ProjectFactory();
        
        // Get requests
        public List<Domain.Project> GetAll()
        {
            var projects = new List<Domain.Project>();

            var command = Database.GetCommand(ReqGetAll);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            // Add all projects
            while(reader.Read()) projects.Add(_projectFactory.CreateFromSqlReader(reader));

            return projects;
        }

        public Domain.Project GetById(int id)
        {
            var command = Database.GetCommand(ReqGetById);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColId, id);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            // Return the project if found, null if not
            return reader.Read() ? _projectFactory.CreateFromSqlReader(reader) : null;
        }

        public Domain.Project GetByName(string name)
        {
            var command = Database.GetCommand(ReqGetByName);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColName, name);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            // Return the project if found, null if not
            return reader.Read() ? _projectFactory.CreateFromSqlReader(reader) : null;
        }

        public List<Domain.Project> GetActiveProject()
        {
            var projects = new List<Domain.Project>();
            
            var command = Database.GetCommand(ReqGetActiveProject);
            
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            // Return the project if found, null if not
            while(reader.Read()) projects.Add(_projectFactory.CreateFromSqlReader(reader));
            
            return projects;
        }

        public List<Domain.Project> GetActiveProjectByUser(int idUser)
        {
            var projects = new List<Domain.Project>();
            
            var command = Database.GetCommand(ReqGetActiveProjectByUser);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColIdUser, idUser);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            // Return the project if found, null if not
            while(reader.Read()) projects.Add(_projectFactory.CreateFromSqlReader(reader));
            
            return projects;
        }

        public List<Domain.Project> GetProjectByIdUserNotFinishedIsLinked(int idUser)
        {
            var projects = new List<Domain.Project>();
            
            var command = Database.GetCommand(ReqGetProjectNotFinishedIsLinked);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColIdUser, idUser);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            // Return the project if found, null if not
            while(reader.Read()) projects.Add(_projectFactory.CreateFromSqlReader(reader));
            
            return projects;
        }

        // Post requests
        public Domain.Project Create(Domain.Project project)
        {
            var command = Database.GetCommand(ReqCreate);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColName, project.Name);
            command.Parameters.AddWithValue("@" + ColDeadline, project.Deadline);
            command.Parameters.AddWithValue("@" + ColDescription, project.Description);
            command.Parameters.AddWithValue("@" + ColRepositoryUrl, project.RepositoryUrl);

            return new Domain.Project
            {
                Id = (int) command.ExecuteScalar(),
                Name = project.Name,
                Deadline = project.Deadline,
                Description = project.Description,
                RepositoryUrl = project.RepositoryUrl,
            };
        }
        
        // Put requests
        public bool UpdateRepositoryUrl(int id, string newRepositoryUrl)
        {
            var command = Database.GetCommand(ReqUpdateRepositoryUrl);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColRepositoryUrl, newRepositoryUrl);
            command.Parameters.AddWithValue("@" + ColId, id);

            return command.ExecuteNonQuery() > 0;
        }

        public bool UpdateStatus(int id, int state)
        {
            var command = Database.GetCommand(ReqUpdateState);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColStatus, state);
            command.Parameters.AddWithValue("@" + ColId, id);

            return command.ExecuteNonQuery() > 0;
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