using System.Collections.Generic;
using Application.UseCases.UserStory.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.UserStory;

namespace Application.UseCases.UserStory
{
    public class UseCaseGetAllUserStories : IQuery<List<OutputDtoUserStory>>
    {
        private readonly IUserStoryRepository _userStoryRepository;

        public UseCaseGetAllUserStories(IUserStoryRepository userStoryRepository)
        {
            _userStoryRepository = userStoryRepository;
        }
        public List<OutputDtoUserStory> Execute()
        {
            var userStoriesFromDb = _userStoryRepository.GetAll();

            return Mapper.GetInstance().Map<List<OutputDtoUserStory>>(userStoriesFromDb);
        }
    }
}