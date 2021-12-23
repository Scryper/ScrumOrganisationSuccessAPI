using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.UserStory
{
    public interface IUserStoryRepository
    {
        // Get requests
        List<Domain.UserStory> GetAll();
        List<Domain.UserStory> GetByIdProject(int idProject);
        Domain.UserStory GetById(int id);

        List<Domain.UserStory> GetByIdSprint(int idSprint);
        
        // Post requests
        Domain.UserStory Create(Domain.UserStory userStory);
        
        // Put requests
        bool Update(int id, int idProject, string nom, string description, int priority);
        
        // Delete requests
        bool Delete(int id);
    }
}