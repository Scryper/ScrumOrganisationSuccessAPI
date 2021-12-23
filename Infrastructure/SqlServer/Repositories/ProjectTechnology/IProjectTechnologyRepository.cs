using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.ProjectTechnology
{
    public interface IProjectTechnologyRepository
    {
        // Get Requests
        List<Domain.ProjectTechnology> GetAll();

        List<Domain.ProjectTechnology> GetByIdProject(int idProject);

        List<Domain.ProjectTechnology> getByIdTechnology(int idTechnology);

        
        // Post Requests
        Domain.ProjectTechnology Create(Domain.ProjectTechnology projectTechnology);
        
        // Delete Requests
        bool Delete(int idUser, int idTechnology);
    }
}