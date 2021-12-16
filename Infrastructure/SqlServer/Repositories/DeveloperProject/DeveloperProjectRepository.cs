using System.Collections.Generic;
using System.Data;
using Domain;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.developer_project
{
    public partial class DeveloperProjectRepository : IDeveloperProjectRepository
    {
        private readonly IDomainFactory<DeveloperProject> _developerProjectFactory =
            new DeveloperProjectFactory();

        // Get requests
        public List<DeveloperProject> GetAll()
        {
            var developerProjects = new List<DeveloperProject>();

            var command = Database.GetCommand(ReqGetAll);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            while(reader.Read()) developerProjects.Add(_developerProjectFactory.CreateFromSqlReader(reader));

            return developerProjects;
        }

        public List<DeveloperProject> GetByIdDeveloper(int idDeveloper)
        {
            var developerProjects = new List<DeveloperProject>();

            var command = Database.GetCommand((ReqGetByDeveloperId));

            command.Parameters.AddWithValue("@" + ColIdDeveloper, idDeveloper);
            
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            while(reader.Read()) developerProjects.Add(_developerProjectFactory.CreateFromSqlReader(reader));

            return developerProjects;
        }

        public List<DeveloperProject> GetByIdProject(int idProject)
        {
            var developerProjects = new List<DeveloperProject>();

            var command = Database.GetCommand((ReqGetByProjectId));

            command.Parameters.AddWithValue("@" + ColIdProject, idProject);
            
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            while(reader.Read()) developerProjects.Add(_developerProjectFactory.CreateFromSqlReader(reader));

            return developerProjects;
        }

        // Post requests
        public DeveloperProject Create(DeveloperProject developerProject)
        {
            var command = Database.GetCommand((ReqCreate));

            command.Parameters.AddWithValue("@" + ColIdDeveloper, developerProject.IdDeveloper);
            command.Parameters.AddWithValue("@" + ColIdProject, developerProject.IdProject);
            command.Parameters.AddWithValue("@" + ColIsAppliance, developerProject.IsAppliance);

            command.ExecuteNonQuery();
            
            return new DeveloperProject
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