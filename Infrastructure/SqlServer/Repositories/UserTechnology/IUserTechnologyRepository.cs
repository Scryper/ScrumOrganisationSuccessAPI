using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.UserTechnology
{
    public interface IUserTechnologyRepository
    {
        // Get Requests
        List<Domain.UserTechnology> GetAll();

        List<Domain.UserTechnology> GetByIdUser(int userId);

        List<Domain.UserTechnology> GetByIdTechnology(int technologyId);

        List<Domain.UserTechnology> GetByIdTechnologyIdUser(int technologyId, int idUser);
        
        // Post Requests
        Domain.UserTechnology Create(Domain.UserTechnology userTechnology);
        
        // Delete Requests
       bool Delete(int idUser, int idTechnology);
    }
}