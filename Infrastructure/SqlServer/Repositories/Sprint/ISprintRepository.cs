using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.Sprint
{
    public interface ISprintRepository
    {
        // Get requests
        List<Domain.Sprint> GetAll();
        List<Domain.Sprint> GetByIdProject(int idProject);
        Domain.Sprint GetById(int id);

        // Post requests
        Domain.Sprint Create(Domain.Sprint sprint);
    }
}