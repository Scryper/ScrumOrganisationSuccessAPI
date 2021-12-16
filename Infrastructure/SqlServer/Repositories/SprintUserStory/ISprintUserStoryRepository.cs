using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.SprintUserStory
{
    public interface ISprintUserStoryRepository
    {
        // Get requests
        List<Domain.SprintUserStory> GetAll();
        List<Domain.SprintUserStory> GetByIdSprint(int idSprint);
        List<Domain.SprintUserStory> GetByIdUserStory(int idUserStory);

        // Post requests
        Domain.SprintUserStory Create(Domain.SprintUserStory sprintUserStory);

        // Delete requests
        bool Delete(int idSprint, int idUserStory);
    }
}