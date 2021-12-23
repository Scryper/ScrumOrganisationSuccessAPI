using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.User
{
    public interface IUserRepository
    {
        // Get requests
        List<Domain.User> GetAll();
        List<Domain.User> GetByIdProject(int idProject);
        
        List<Domain.User> GetByIdProjectIsWorking(int idProject);
        List<Domain.User> GetByIdMeeting(int idMeeting);
        Domain.User GetById(int id);
        Domain.User GetByEmail(string email);
        List<Domain.User> GetUserByCommentOnUserStory(int idUserStory);

        List<Domain.User> GetByIdProjectIsApplying(int idProject);

        // Post requests
        Domain.User Create(Domain.User user);
        
        // Put requests
        bool UpdateRole(int id, int newRole);
        bool UpdatePassword(int id, string newPassword);
        bool UpdateEmail(int id, string newEmail);
        bool UpdateFirstNameLastName(int id, string firstname, string lastname);

        // Delete requests
        bool Delete(int id);
    }
}