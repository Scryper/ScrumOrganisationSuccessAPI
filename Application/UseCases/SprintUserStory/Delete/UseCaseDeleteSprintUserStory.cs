using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.SprintUserStory;

namespace Application.UseCases.SprintUserStory.Delete
{
    public class UseCaseDeleteSprintUserStory : IWritingMultipleKeys<bool, int, int>
    {
        private readonly ISprintUserStoryRepository _sprintUserStoryRepository;

        public UseCaseDeleteSprintUserStory(ISprintUserStoryRepository sprintUserStoryRepository)
        {
            _sprintUserStoryRepository = sprintUserStoryRepository;
        }
        public bool Execute(int idSprint, int idUserStory)
        {
            return _sprintUserStoryRepository.Delete(idSprint, idUserStory);
        }
    }
}