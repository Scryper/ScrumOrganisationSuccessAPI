using Application.UseCases.UserStory.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.UserStory;

namespace Application.UseCases.UserStory.Get
{
    public class UseCaseGetUserStoryById : IQueryFiltering<OutputDtoUserStory, int>
    {
        private readonly IUserStoryRepository _userStoryRepository;

        public UseCaseGetUserStoryById(IUserStoryRepository userStoryRepository)
        {
            _userStoryRepository = userStoryRepository;
        }

        public OutputDtoUserStory Execute(int filter)
        {
            var userStory = _userStoryRepository.GetById(filter);

            return Mapper.GetInstance().Map<OutputDtoUserStory>(userStory);
        }
    }
}