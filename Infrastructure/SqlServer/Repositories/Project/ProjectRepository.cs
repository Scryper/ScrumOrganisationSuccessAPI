using System.Collections.Generic;
using System.Data;
using System.Linq;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.Project
{
    public partial class ProjectRepository : IProjectRepository
    {
        private readonly IDomainFactory<Domain.Project> _projectFactory = new ProjectFactory();
        private readonly RequestHelper<Domain.Project> _requestHelper = new RequestHelper<Domain.Project>();
        
        // Get requests
        public List<Domain.Project> GetAll()
        {
            return _requestHelper.GetAll(ReqGetAll, _projectFactory);
        }

        public Domain.Project GetById(int id)
        {
            return _requestHelper.GetById(id, ColId, ReqGetById, _projectFactory);
        }
        
        public List<Domain.Project> GetActiveProjectByUser(int idUser)
        {
            return _requestHelper.GetByIdHelper(idUser, ColIdUser, ReqGetActiveProjectByUser, _projectFactory);
        }

        public List<Domain.Project> GetProjectByIdUserNotFinishedIsLinked(int idUser)
        {
            return _requestHelper.GetByIdHelper(idUser, ColIdUser, ReqGetProjectNotFinishedIsLinked, _projectFactory);
        }
        
        public Domain.Project GetByName(string name)
        {
            return _requestHelper.GetByName(name, ColName, ReqGetByName, _projectFactory);
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
        
        // Post requests
        public Domain.Project Create(Domain.Project project)
        {
            if (Exists(project)) return null;
            
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
        
        // Utils for post request
        private bool Exists(Domain.Project project)
        {
            var projects = GetAll();

            return Enumerable.Contains(projects, project);
        }
        
        // Put requests
        public bool UpdateStatus(int id, int state)
        {
            var command = Database.GetCommand(ReqUpdateState);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColStatus, state);
            command.Parameters.AddWithValue("@" + ColId, id);

            return command.ExecuteNonQuery() > 0;
        }
    }
}