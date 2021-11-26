using System.Collections.Generic;
using Application.UseCases.UserStory.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.UserStory;

namespace Application.UseCases.UserStory.Get
{
    public class UseCaseGetUserStoriesByIdProject : IQueryFiltering<List<OutputDtoUserStory>, int>
    {
        private readonly IUserStoryRepository _userStoryRepository;

        public UseCaseGetUserStoriesByIdProject(IUserStoryRepository userStoryRepository)
        {
            _userStoryRepository = userStoryRepository;
        }

        public List<OutputDtoUserStory> Execute(int filter)
        {
            var userStories = _userStoryRepository.GetByIdProject(filter);

            return Mapper.GetInstance().Map<List<OutputDtoUserStory>>(userStories);
        }
    }
}