using Application.UseCases.UserStory.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.UserStory;

namespace Application.UseCases.UserStory.Put
{
    public class UseCaseUpdateUserStoryIsDone : IWriting<bool, InputDtoUpdateUserStoryIsDone>
    {
        private readonly IUserStoryRepository _userStoryRepository;

        public UseCaseUpdateUserStoryIsDone(IUserStoryRepository userStoryRepository)
        {
            _userStoryRepository = userStoryRepository;
        }

        public bool Execute(InputDtoUpdateUserStoryIsDone data)
        {
            return _userStoryRepository.UpdateIsDone(data.Id, data.InternUserStory.IsDone);
        }
    }
}