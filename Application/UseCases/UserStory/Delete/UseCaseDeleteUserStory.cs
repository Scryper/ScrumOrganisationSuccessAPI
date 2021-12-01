using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.UserStory;

namespace Application.UseCases.UserStory.Delete
{
    public class UseCaseDeleteUserStory : IWriting<bool, int>
    {
        private readonly IUserStoryRepository _userStoryRepository;

        public UseCaseDeleteUserStory(IUserStoryRepository userStoryRepository)
        {
            _userStoryRepository = userStoryRepository;
        }
        
        public bool Execute(int data)
        {
            return _userStoryRepository.Delete(data);
        }
    }
}