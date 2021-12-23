using Application.UseCases.UserStory.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.UserStory;

namespace Application.UseCases.UserStory.Put
{
    public class UseCaseUpdateUserStory : IWriting<bool,InputDtoUpdateUserStory>
    {
        private readonly IUserStoryRepository _userStoryRepository;

        public UseCaseUpdateUserStory(IUserStoryRepository userStoryRepository)
        {
            _userStoryRepository = userStoryRepository;
        }
        
        public bool Execute(InputDtoUpdateUserStory data)
        {
            return _userStoryRepository.Update(data.Id,
                data.InternUserStory.IdProject,
                data.InternUserStory.Name,
                data.InternUserStory.Description,
                data.InternUserStory.Priority);
        }
    }
}