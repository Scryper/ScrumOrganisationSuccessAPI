using System.Collections.Generic;
using System.Data;
using Infrastructure.SqlServer.Utils;
using NotImplementedException = System.NotImplementedException;

namespace Infrastructure.SqlServer.Repositories.DeveloperProject
{
    public partial class DeveloperProjectRepository : IDeveloperProjectRepository
    {
        private readonly IDomainFactory<Domain.DeveloperProject> _developerProjectFactory =
            new DeveloperProjectFactory();

        // Get requests
        public List<Domain.DeveloperProject> GetAll()
        {
            var developerProjects = new List<Domain.DeveloperProject>();

            var command = Database.GetCommand(ReqGetAll);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            while(reader.Read()) developerProjects.Add(_developerProjectFactory.CreateFromSqlReader(reader));

            return developerProjects;
        }

        public List<Domain.DeveloperProject> GetByIdDeveloper(int idDeveloper)
        {
            var developerProjects = new List<Domain.DeveloperProject>();

            var command = Database.GetCommand(ReqGetByDeveloperId);

            command.Parameters.AddWithValue("@" + ColIdDeveloper, idDeveloper);
            
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            while(reader.Read()) developerProjects.Add(_developerProjectFactory.CreateFromSqlReader(reader));

            return developerProjects;
        }

        public List<Domain.DeveloperProject> GetByIdProject(int idProject)
        {
            var developerProjects = new List<Domain.DeveloperProject>();

            var command = Database.GetCommand(ReqGetByProjectId);

            command.Parameters.AddWithValue("@" + ColIdProject, idProject);
            
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            while(reader.Read()) developerProjects.Add(_developerProjectFactory.CreateFromSqlReader(reader));

            return developerProjects;
        }

        public List<Domain.DeveloperProject> GetByIdDeveloperIsAppliance(int idDeveloper)
        {
            var developerProjects = new List<Domain.DeveloperProject>();
            
            var command = Database.GetCommand(ReqByIdDeveloperIsAppliance);

            command.Parameters.AddWithValue("@" + ColIdDeveloper, idDeveloper);
            
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            while(reader.Read()) developerProjects.Add(_developerProjectFactory.CreateFromSqlReader(reader));

            return developerProjects;
        }

        public Domain.DeveloperProject GetByIdDeveloperIdProject(int idDeveloper, int idProject)
        {
            var developerProjects = new Domain.DeveloperProject();

            var command = Database.GetCommand(ReqGetByIdDeveloperIdProject);
            
            command.Parameters.AddWithValue("@" + ColIdDeveloper, idDeveloper);
            command.Parameters.AddWithValue("@" + ColIdProject, idProject);
            
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            // Return the project if found, null if not
            return reader.Read() ? _developerProjectFactory.CreateFromSqlReader(reader) : null;
        }

        public List<Domain.DeveloperProject> GetByIdDeveloperifIsWorking(int idDeveloper)
        {
            var developerProjects = new List<Domain.DeveloperProject>();
            
            var command = Database.GetCommand(ReqDeveloperProjectByIdDeveloperIfIsWorking);

            command.Parameters.AddWithValue("@" + ColIdDeveloper, idDeveloper);
            
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            while(reader.Read()) developerProjects.Add(_developerProjectFactory.CreateFromSqlReader(reader));

            return developerProjects;
        }

        public List<Domain.DeveloperProject> GetByIdDeveloperifIsNotWorking(int idDeveloper)
        {
            var developerProjects = new List<Domain.DeveloperProject>();
            
            var command = Database.GetCommand(ReqDeveloperProjectByIdDeveloperifIsNotWorking);

            command.Parameters.AddWithValue("@" + ColIdDeveloper, idDeveloper);
            
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            while(reader.Read()) developerProjects.Add(_developerProjectFactory.CreateFromSqlReader(reader));

            return developerProjects;
        }

        public List<Domain.DeveloperProject> GetScrumMasterByIdProject(int idDeveloper)
        {
            throw new NotImplementedException();
        }

        public List<Domain.DeveloperProject> GetDevsByIdProject(int idDeveloper)
        {
            throw new NotImplementedException();
        }

        // Post requests
        public Domain.DeveloperProject Create(Domain.DeveloperProject developerProject)
        {
            var command = Database.GetCommand(ReqCreate);

            command.Parameters.AddWithValue("@" + ColIdDeveloper, developerProject.IdDeveloper);
            command.Parameters.AddWithValue("@" + ColIdProject, developerProject.IdProject);
            command.Parameters.AddWithValue("@" + ColIsAppliance, developerProject.IsAppliance);

            command.ExecuteNonQuery();
            
            return new Domain.DeveloperProject
            {
                IdDeveloper = developerProject.IdDeveloper,
                IdProject = developerProject.IdProject,
                IsAppliance = developerProject.IsAppliance
            };
        }

        // Put requests
        public bool Update(int idDeveloper, int idProject, bool isAppliance)
        {
            var command = Database.GetCommand(ReqUpdate);
            
            command.Parameters.AddWithValue("@" + ColIdDeveloper, idDeveloper);
            command.Parameters.AddWithValue("@" + ColIdProject, idProject);
            command.Parameters.AddWithValue("@" + ColIsAppliance, isAppliance);

            return command.ExecuteNonQuery() > 0;
        }

        // Delete requests
        public bool Delete(int idDeveloper, int idProject)
        {
            var command = Database.GetCommand(ReqDelete);
            
            command.Parameters.AddWithValue("@" + ColIdDeveloper, idDeveloper);
            command.Parameters.AddWithValue("@" + ColIdProject, idProject);
            
            return command.ExecuteNonQuery() > 0;
        }
    }
}