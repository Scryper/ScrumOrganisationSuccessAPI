using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.developer_project
{
    public interface IDeveloperProjectRepository
    {
        // Get requests
        List<Domain.DeveloperProject> GetAll();
        
        List<Domain.DeveloperProject> GetByIdDeveloper(int idDeveloper);
        
        List<Domain.DeveloperProject> GetByIdProject(int idProject);

        // Post requests
        Domain.DeveloperProject Create(Domain.DeveloperProject developerProject);
        
        // Put requests
        bool Update(int idDeveloper, int idProject, bool isAppliance);

        // Delete requests
        bool Delete(int idDeveloper, int idProject);
    }
}