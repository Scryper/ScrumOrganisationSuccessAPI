using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.UserProject
{
    public interface IUserProjectRepository
    {
        // Get requests
        List<Domain.UserProject> GetAll();
        List<Domain.UserProject> GetByIdDeveloper(int idDeveloper);
        List<Domain.UserProject> GetByIdProject(int idProject);
        List<Domain.UserProject> GetByIdDeveloperIsAppliance(int idDeveloper);
        Domain.UserProject GetByIdDeveloperIdProject(int idDeveloper, int idProject);
        List<Domain.UserProject> GetByIdDeveloperifIsWorking(int idDeveloper);
        List<Domain.UserProject> GetByIdDeveloperifIsNotWorking(int idDeveloper);
        List<Domain.UserProject> GetScrumMasterByIdProject(int idDeveloper);
        List<Domain.UserProject> GetDevsByIdProject(int idDeveloper);
        List<Domain.Sprint> GetSprintByIdDeveloper(int idDeveloper);
        
        // Post requests
        Domain.UserProject Create(Domain.UserProject userProject);
        
        // Put requests
        bool Update(int idDeveloper, int idProject, bool isAppliance);

        // Delete requests
        bool Delete(int idDeveloper, int idProject);
    }
}