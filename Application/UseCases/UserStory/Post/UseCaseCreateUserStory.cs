using Application.UseCases.UserStory.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.UserStory;

namespace Application.UseCases.UserStory.Post
{
    public class UseCaseCreateUserStory : IWriting<OutputDtoUserStory, InputDtoUserStory>
    {
        private readonly IUserStoryRepository _userStoryRepository;

        public UseCaseCreateUserStory(IUserStoryRepository userStoryRepository)
        {
            _userStoryRepository = userStoryRepository;
        }
        
        public OutputDtoUserStory Execute(InputDtoUserStory dto)
        {
            var userStoryFromDb = Mapper.GetInstance().Map<Domain.UserStory>(dto);
            
            var userStory = _userStoryRepository.Create(userStoryFromDb);
            
            return Mapper.GetInstance().Map<OutputDtoUserStory>(userStory);
        }
    }
}