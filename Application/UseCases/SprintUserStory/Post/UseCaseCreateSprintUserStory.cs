using Application.UseCases.SprintUserStory.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.SprintUserStory;

namespace Application.UseCases.SprintUserStory.Post
{
    public class UseCaseCreateSprintUserStory : IWriting<OutputDtoSprintUserStory, InputDtoSprintUserStory>
    {
        private readonly ISprintUserStoryRepository _sprintUserStoryRepository;

        public UseCaseCreateSprintUserStory(ISprintUserStoryRepository sprintUserStoryRepository)
        {
            _sprintUserStoryRepository = sprintUserStoryRepository;
        }
        public OutputDtoSprintUserStory Execute(InputDtoSprintUserStory data)
        {
            var sprintUserStoryFromDto = Mapper.GetInstance().Map<Domain.SprintUserStory>(data);

            var sprintUserStory = _sprintUserStoryRepository.Create(sprintUserStoryFromDto);

            return Mapper.GetInstance().Map<OutputDtoSprintUserStory>(sprintUserStory);
        }
    }
}