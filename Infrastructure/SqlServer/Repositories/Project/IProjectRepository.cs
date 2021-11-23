using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.Project
{
    public interface IProjectRepository
    {
        // Get requests
        List<Domain.Project> GetAll();
        Domain.Project GetById(int id);
        List<Domain.Project> GetByIdProductOwner(int idProductOwner);
        List<Domain.Project> GetByIdScrumMaster(int idScrumMaster);

        // Post requests
        Domain.Project Create(Domain.Project project);
        
        // Put requests
        bool UpdateRepositoryUrl(int id, Domain.Project newProject);

        // Delete requests
        bool Delete(int id);
    }
}