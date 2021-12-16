using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.ProjectTechnology
{
    public interface IProjectTechnologyRepository
    {
        // Get Requests
        List<Domain.ProjectTechnology> GetAll();

        List<Domain.ProjectTechnology> GetByProjectId(int projectId);

        List<Domain.ProjectTechnology> getByTechnologyId(int technologyId);

        
        // Post Requests
        Domain.ProjectTechnology Create(Domain.ProjectTechnology projectTechnology);
        
        // Delete Requests
        bool Delete(int idUser, int idTechnology);
    }
}