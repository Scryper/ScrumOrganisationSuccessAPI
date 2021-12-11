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
        Domain.User GetByEmail(string email);

        // Post requests
        Domain.User Create(Domain.User user);
        
        // Put requests
        bool UpdateRole(int id, int newRole);
        bool UpdatePassword(int id, string newPassword);
        bool UpdateEmail(int id, string newEmail);

        // Delete requests
        bool Delete(int id);
    }
}