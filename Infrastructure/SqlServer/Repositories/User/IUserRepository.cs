using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.User
{
    public interface IUserRepository
    {
        // Get requests
        List<Domain.User> GetAll();
        List<Domain.User> GetByIdProject(int idProject);
        List<Domain.User> GetByIdMeeting(int idMeeting);
        Domain.User GetById(int id);

        // Post requests
        Domain.User Create(Domain.User user);
        
        // Put requests
        bool UpdateRole(int id, Domain.User newUser);
        bool UpdatePassword(int id, Domain.User newUser);
        bool UpdateEmail(int id, Domain.User newUser);
        bool UpdatePseudo(int id, Domain.User newUser);

        // Delete requests
        bool Delete(int id);
    }
}