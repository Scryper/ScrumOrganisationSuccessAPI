using System.Collections.Generic;
using System.Data;
using Infrastructure.SqlServer.Repositories.DeveloperProject;
using Infrastructure.SqlServer.Repositories.Sprint;
using Infrastructure.SqlServer.Utils;
using NotImplementedException = System.NotImplementedException;

namespace Infrastructure.SqlServer.Repositories.UserProject
{
    public partial class UserProjectRepository : IUserProjectRepository
    {
        private readonly IDomainFactory<Domain.UserProject> _developerProjectFactory =
            new UserProjectFactory();

        private readonly IDomainFactory<Domain.Sprint> _sprintFactory = new SprintFactory();

        // Get requests
        public List<Domain.UserProject> GetAll()
        {
            var developerProjects = new List<Domain.UserProject>();

            var command = Database.GetCommand(ReqGetAll);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            while(reader.Read()) developerProjects.Add(_developerProjectFactory.CreateFromSqlReader(reader));

            return developerProjects;
        }

        public List<Domain.UserProject> GetByIdDeveloper(int idDeveloper)
        {
            var developerProjects = new List<Domain.UserProject>();

            var command = Database.GetCommand(ReqGetByDeveloperId);

            command.Parameters.AddWithValue("@" + ColIdUser, idDeveloper);
            
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            while(reader.Read()) developerProjects.Add(_developerProjectFactory.CreateFromSqlReader(reader));

            return developerProjects;
        }

        public List<Domain.UserProject> GetByIdProject(int idProject)
        {
            var developerProjects = new List<Domain.UserProject>();

            var command = Database.GetCommand(ReqGetByProjectId);

            command.Parameters.AddWithValue("@" + ColIdProject, idProject);
            
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            while(reader.Read()) developerProjects.Add(_developerProjectFactory.CreateFromSqlReader(reader));

            return developerProjects;
        }

        public List<Domain.UserProject> GetByIdDeveloperIsAppliance(int idDeveloper)
        {
            var developerProjects = new List<Domain.UserProject>();
            
            var command = Database.GetCommand(ReqByIdDeveloperIsAppliance);

            command.Parameters.AddWithValue("@" + ColIdUser, idDeveloper);
            
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            while(reader.Read()) developerProjects.Add(_developerProjectFactory.CreateFromSqlReader(reader));

            return developerProjects;
        }

        public Domain.UserProject GetByIdDeveloperIdProject(int idDeveloper, int idProject)
        {
            var developerProjects = new Domain.UserProject();

            var command = Database.GetCommand(ReqGetByIdDeveloperIdProject);
            
            command.Parameters.AddWithValue("@" + ColIdUser, idDeveloper);
            command.Parameters.AddWithValue("@" + ColIdProject, idProject);
            
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            // Return the project if found, null if not
            return reader.Read() ? _developerProjectFactory.CreateFromSqlReader(reader) : null;
        }

        public List<Domain.UserProject> GetByIdDeveloperifIsWorking(int idDeveloper)
        {
            var developerProjects = new List<Domain.UserProject>();
            
            var command = Database.GetCommand(ReqDeveloperProjectByIdDeveloperIfIsWorking);

            command.Parameters.AddWithValue("@" + ColIdUser, idDeveloper);
            
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            while(reader.Read()) developerProjects.Add(_developerProjectFactory.CreateFromSqlReader(reader));

            return developerProjects;
        }

        public List<Domain.UserProject> GetByIdDeveloperifIsNotWorking(int idDeveloper)
        {
            var developerProjects = new List<Domain.UserProject>();
            
            var command = Database.GetCommand(ReqDeveloperProjectByIdDeveloperifIsNotWorking);

            command.Parameters.AddWithValue("@" + ColIdUser, idDeveloper);
            
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            while(reader.Read()) developerProjects.Add(_developerProjectFactory.CreateFromSqlReader(reader));

            return developerProjects;
        }

        public List<Domain.UserProject> GetScrumMasterByIdProject(int idProject)
        {
            var developerProjects = new List<Domain.UserProject>();
            
            var command = Database.GetCommand(ReqGetScrumMasterByIdProject);

            command.Parameters.AddWithValue("@" + ColIdProject, idProject);
            
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            while(reader.Read()) developerProjects.Add(_developerProjectFactory.CreateFromSqlReader(reader));

            return developerProjects;
        }

        public List<Domain.UserProject> GetDevsByIdProject(int idProject)
        {
            var developerProjects = new List<Domain.UserProject>();
            
            var command = Database.GetCommand(ReqGetDevsByIdProject);

            command.Parameters.AddWithValue("@" + ColIdProject, idProject);
            
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            while(reader.Read()) developerProjects.Add(_developerProjectFactory.CreateFromSqlReader(reader));

            return developerProjects;
        }

        public List<Domain.Sprint> GetSprintByIdDeveloper(int idDeveloper)
        {
            var sprints = new List<Domain.Sprint>();
                        
            var command = Database.GetCommand(ReqGetSprintsByIdDeveloper);

            command.Parameters.AddWithValue("@" + ColIdUser, idDeveloper);
            
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            while(reader.Read()) sprints.Add(_sprintFactory.CreateFromSqlReader(reader));

            return sprints;
        }
        

        // Post requests
        public Domain.UserProject Create(Domain.UserProject userProject)
        {
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