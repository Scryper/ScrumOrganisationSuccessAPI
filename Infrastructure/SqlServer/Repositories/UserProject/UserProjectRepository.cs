using System.Collections.Generic;
using System.Data;
using System.Linq;
using Infrastructure.SqlServer.Repositories.DeveloperProject;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.UserProject
{
    public partial class UserProjectRepository : IUserProjectRepository
    {
        private readonly IDomainFactory<Domain.UserProject> _userProjectFactory =
            new UserProjectFactory();

        private readonly RequestHelper<Domain.UserProject> _requestHelper = new RequestHelper<Domain.UserProject>();

        // Get requests
        public List<Domain.UserProject> GetAll()
        {
            return _requestHelper.GetAll(ReqGetAll, _userProjectFactory);
        }
        
        public List<Domain.UserProject> GetByIdDeveloper(int idDeveloper)
        {
            return _requestHelper.GetByIdHelper(idDeveloper, ColIdUser, ReqGetByDeveloperId, _userProjectFactory);
        }

        public List<Domain.UserProject> GetByIdDeveloperIsAppliance(int idDeveloper)
        {
            return  _requestHelper.GetByIdHelper(idDeveloper, ColIdUser, ReqByIdDeveloperIsAppliance, _userProjectFactory);
        }

        public List<Domain.UserProject> GetByIdDeveloperIfIsWorking(int idDeveloper)
        {
            return  _requestHelper.GetByIdHelper(idDeveloper, ColIdUser, ReqDeveloperProjectByIdDeveloperIfIsWorking, _userProjectFactory);
        }

        public List<Domain.UserProject> GetByIdDeveloperIfIsNotWorking(int idDeveloper)
        {
            return  _requestHelper.GetByIdHelper(idDeveloper, ColIdUser, ReqDeveloperProjectByIdDeveloperifIsNotWorking, _userProjectFactory);
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