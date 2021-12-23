using System.Collections.Generic;
using System.Data;
using System.Linq;
using Infrastructure.SqlServer.Repositories.DeveloperProject;
using Infrastructure.SqlServer.Repositories.Sprint;
using Infrastructure.SqlServer.Utils;
using NotImplementedException = System.NotImplementedException;

namespace Infrastructure.SqlServer.Repositories.UserProject
{
    public partial class UserProjectRepository : IUserProjectRepository
    {
        private readonly IDomainFactory<Domain.UserProject> _userProjectFactory =
            new UserProjectFactory();

        private readonly IDomainFactory<Domain.Sprint> _sprintFactory = new SprintFactory();

        // Get requests
        public List<Domain.UserProject> GetAll()
        {
            var developerProjects = new List<Domain.UserProject>();

            var command = Database.GetCommand(ReqGetAll);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            while(reader.Read()) developerProjects.Add(_userProjectFactory.CreateFromSqlReader(reader));

            return developerProjects;
        }
        
        public Domain.UserProject GetByIdDeveloperIdProject(int idDeveloper, int idProject)
        {
            var command = Database.GetCommand(ReqGetByIdDeveloperIdProject);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColIdUser, idDeveloper);
            command.Parameters.AddWithValue("@" + ColIdProject, idProject);
            
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            // Return the project if found, null if not
            return reader.Read() ? _userProjectFactory.CreateFromSqlReader(reader) : null;
        }

        // Utils for GetByIdDeveloper, GetByIdProject, GetByIdDeveloperIsAppliance, GetByIdDeveloperIfIsWorking
        // GetByIdDeveloperIfIsNotWorking, GetScrumMasterByIdProject, GetDevelopersByIdProject
        // Both return a list of user projects, the only changing parameters are the request and the column on which 
        // the request base its verification
        private List<Domain.UserProject> GetByIdHelper(int id, string column, string request)
        {
            var userProjects = new List<Domain.UserProject>();
            
            var command = Database.GetCommand(request);
            
            command.Parameters.AddWithValue("@" + column, id);
            
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            while(reader.Read()) userProjects.Add(_userProjectFactory.CreateFromSqlReader(reader));
            
            return userProjects;
        }
        
        public List<Domain.UserProject> GetByIdDeveloper(int idDeveloper)
        {
            return GetByIdHelper(idDeveloper, ColIdUser, ReqGetByDeveloperId);
        }

        public List<Domain.UserProject> GetByIdProject(int idProject)
        {
            return GetByIdHelper(idProject, ColIdProject, ReqGetByProjectId);
        }

        public List<Domain.UserProject> GetByIdDeveloperIsAppliance(int idDeveloper)
        {
            return GetByIdHelper(idDeveloper, ColIdUser, ReqByIdDeveloperIsAppliance);
        }

        public List<Domain.UserProject> GetByIdDeveloperIfIsWorking(int idDeveloper)
        {
            return GetByIdHelper(idDeveloper, ColIdUser, ReqDeveloperProjectByIdDeveloperIfIsWorking);
        }

        public List<Domain.UserProject> GetByIdDeveloperIfIsNotWorking(int idDeveloper)
        {
            return GetByIdHelper(idDeveloper, ColIdUser, ReqDeveloperProjectByIdDeveloperifIsNotWorking);
        }

        public List<Domain.UserProject> GetScrumMasterByIdProject(int idProject)
        {
            return GetByIdHelper(idProject, ColIdProject, ReqGetScrumMasterByIdProject);
        }

        public List<Domain.UserProject> GetDevelopersByIdProject(int idProject)
        {
            return GetByIdHelper(idProject, ColIdProject, ReqGetDevelopersByIdProject);
        }
        
        // Post requests
        public Domain.UserProject Create(Domain.UserProject userProject)
        {
            if (Exists(userProject)) return null;
            
            var command = Database.GetCommand(ReqCreate);

            command.Parameters.AddWithValue("@" + ColIdUser, userProject.IdDeveloper);
            command.Parameters.AddWithValue("@" + ColIdProject, userProject.IdProject);
            command.Parameters.AddWithValue("@" + ColIsAppliance, userProject.IsAppliance);

            command.ExecuteNonQuery();
            
            return new Domain.UserProject
            {
                IdDeveloper = userProject.IdDeveloper,
                IdProject = userProject.IdProject,
                IsAppliance = userProject.IsAppliance
            };
        }
        
        // Utils for post request
        private bool Exists(Domain.UserProject userProject)
        {
            var userProjects = GetAll();
            return Enumerable.Contains(userProjects, userProject);
        }

        // Put requests
        public bool Update(int idDeveloper, int idProject, bool isAppliance)
        {
            var command = Database.GetCommand(ReqUpdate);
            
            command.Parameters.AddWithValue("@" + ColIdUser, idDeveloper);
            command.Parameters.AddWithValue("@" + ColIdProject, idProject);
            command.Parameters.AddWithValue("@" + ColIsAppliance, isAppliance);

            return command.ExecuteNonQuery() > 0;
        }

        // Delete requests
        public bool Delete(int idDeveloper, int idProject)
        {
            var command = Database.GetCommand(ReqDelete);
            
            command.Parameters.AddWithValue("@" + ColIdUser, idDeveloper);
            command.Parameters.AddWithValue("@" + ColIdProject, idProject);
            
            return command.ExecuteNonQuery() > 0;
        }
    }
}