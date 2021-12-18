using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.DeveloperProject
{
    public interface IDeveloperProjectRepository
    {
        // Get requests
        List<Domain.DeveloperProject> GetAll();
        List<Domain.DeveloperProject> GetByIdDeveloper(int idDeveloper);
        List<Domain.DeveloperProject> GetByIdProject(int idProject);
        List<Domain.DeveloperProject> GetByIdDeveloperIsAppliance(int idDeveloper);
        Domain.DeveloperProject GetByIdDeveloperIdProject(int idDeveloper, int idProject);
        List<Domain.DeveloperProject> GetByIdDeveloperifIsWorking(int idDeveloper);
        List<Domain.DeveloperProject> GetByIdDeveloperifIsNotWorking(int idDeveloper);
        List<Domain.DeveloperProject> GetScrumMasterByIdProject(int idDeveloper);
        List<Domain.DeveloperProject> GetDevsByIdProject(int idDeveloper);
        
        // Post requests
        Domain.DeveloperProject Create(Domain.DeveloperProject developerProject);
        
        // Put requests
        bool Update(int idDeveloper, int idProject, bool isAppliance);

        // Delete requests
        bool Delete(int idDeveloper, int idProject);
    }
}