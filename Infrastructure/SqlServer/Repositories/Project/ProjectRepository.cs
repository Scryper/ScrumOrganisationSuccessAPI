using System.Collections.Generic;
using System.Data;
using Infrastructure.SqlServer.Utils;

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

        // TODO : factorisation
        public List<Domain.Project> GetByIdProductOwner(int idProductOwner)
        {
            var projects = new List<Domain.Project>();

            var command = Database.GetCommand(ReqGetByIdProductOwner);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColIdProductOwner, idProductOwner);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            while(reader.Read()) projects.Add(_projectFactory.CreateFromSqlReader(reader));

            return projects;
        }

        // TODO : factorisation
        public List<Domain.Project> GetByIdScrumMaster(int idScrumMaster)
        {
            var projects = new List<Domain.Project>();

            var command = Database.GetCommand(ReqGetByIdScrumMaster);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColIdScrumMaster, idScrumMaster);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            while(reader.Read()) projects.Add(_projectFactory.CreateFromSqlReader(reader));

            return projects;
        }

        // Post requests
        public Domain.Project Create(Domain.Project project)
        {
            var command = Database.GetCommand(ReqCreate);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColIdProductOwner, project.IdProductOwner);
            command.Parameters.AddWithValue("@" + ColIdScrumMaster, project.IdScrumMaster);
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
                IdProductOwner = project.IdProductOwner,
                IdScrumMaster = project.IdScrumMaster
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