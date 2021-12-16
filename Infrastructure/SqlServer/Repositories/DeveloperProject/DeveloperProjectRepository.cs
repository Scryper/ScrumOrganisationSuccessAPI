using System.Collections.Generic;
using System.Data;
using Infrastructure.SqlServer.Utils;

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

            var command = Database.GetCommand(DeveloperProjectRepository.ReqGetAll);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            while(reader.Read()) developerProjects.Add(_developerProjectFactory.CreateFromSqlReader(reader));

            return developerProjects;
        }

        public List<Domain.DeveloperProject> GetByIdDeveloper(int idDeveloper)
        {
            var developerProjects = new List<Domain.DeveloperProject>();

            var command = Database.GetCommand((DeveloperProjectRepository.ReqGetByDeveloperId));

            command.Parameters.AddWithValue("@" + DeveloperProjectRepository.ColIdDeveloper, idDeveloper);
            
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            while(reader.Read()) developerProjects.Add(_developerProjectFactory.CreateFromSqlReader(reader));

            return developerProjects;
        }

        public List<Domain.DeveloperProject> GetByIdProject(int idProject)
        {
            var developerProjects = new List<Domain.DeveloperProject>();

            var command = Database.GetCommand((DeveloperProjectRepository.ReqGetByProjectId));

            command.Parameters.AddWithValue("@" + DeveloperProjectRepository.ColIdProject, idProject);
            
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            while(reader.Read()) developerProjects.Add(_developerProjectFactory.CreateFromSqlReader(reader));

            return developerProjects;
        }

        // Post requests
        public Domain.DeveloperProject Create(Domain.DeveloperProject developerProject)
        {
            var command = Database.GetCommand((DeveloperProjectRepository.ReqCreate));

            command.Parameters.AddWithValue("@" + DeveloperProjectRepository.ColIdDeveloper, developerProject.IdDeveloper);
            command.Parameters.AddWithValue("@" + DeveloperProjectRepository.ColIdProject, developerProject.IdProject);
            command.Parameters.AddWithValue("@" + DeveloperProjectRepository.ColIsAppliance, developerProject.IsAppliance);

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
            var command = Database.GetCommand(DeveloperProjectRepository.ReqUpdate);
            
            command.Parameters.AddWithValue("@" + DeveloperProjectRepository.ColIdDeveloper, idDeveloper);
            command.Parameters.AddWithValue("@" + DeveloperProjectRepository.ColIdProject, idProject);
            command.Parameters.AddWithValue("@" + DeveloperProjectRepository.ColIsAppliance, isAppliance);

            return command.ExecuteNonQuery() > 0;
        }

        // Delete requests
        public bool Delete(int idDeveloper, int idProject)
        {
            var command = Database.GetCommand(DeveloperProjectRepository.ReqDelete);
            
            command.Parameters.AddWithValue("@" + DeveloperProjectRepository.ColIdDeveloper, idDeveloper);
            command.Parameters.AddWithValue("@" + DeveloperProjectRepository.ColIdProject, idProject);
            
            return command.ExecuteNonQuery() > 0;
        }
    }
}