using System.Collections.Generic;
using Application.UseCases.SprintUserStory.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.SprintUserStory;

namespace Application.UseCases.SprintUserStory.Get
{
    public class UseCaseGetSprintUserStoryByIdSprint : IQueryFiltering<List<OutputDtoSprintUserStory>, int>
    {
        private readonly ISprintUserStoryRepository _sprintUserStoryRepository;

        public UseCaseGetSprintUserStoryByIdSprint(ISprintUserStoryRepository sprintUserStoryRepository)
        {
            _sprintUserStoryRepository = sprintUserStoryRepository;
        }

        public List<OutputDtoSprintUserStory> Execute(int filter)
        {
            var sprintUserStoriesFromDb = _sprintUserStoryRepository.GetByIdSprint(filter);

            return Mapper.GetInstance().Map<List<OutputDtoSprintUserStory>>(sprintUserStoriesFromDb);
        }
    }
}