using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.SprintUserStory
{
    public interface ISprintUserStoryRepository
    {
        // Get requests
        List<Domain.SprintUserStory> GetAll();
        List<Domain.SprintUserStory> GetByIdSprint(int idSprint);

        // Post requests
        Domain.SprintUserStory Create(Domain.SprintUserStory sprintUserStory);
    }
}