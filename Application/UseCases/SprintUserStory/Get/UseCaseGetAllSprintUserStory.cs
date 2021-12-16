using System.Collections.Generic;
using Application.UseCases.SprintUserStory.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.SprintUserStory;

namespace Application.UseCases.SprintUserStory.Get
{
    public class UseCaseGetAllSprintUserStory : IQuery<List<OutputDtoSprintUserStory>>
    {
        private readonly ISprintUserStoryRepository _sprintUserStoryRepository;

        public UseCaseGetAllSprintUserStory(ISprintUserStoryRepository sprintUserStoryRepository)
        {
            _sprintUserStoryRepository = sprintUserStoryRepository;
        }

        public List<OutputDtoSprintUserStory> Execute()
        {
            var sprintUsersStoriesFromDb = _sprintUserStoryRepository.GetAll();

            return Mapper.GetInstance().Map<List<OutputDtoSprintUserStory>>(sprintUsersStoriesFromDb);
        }
    }
}