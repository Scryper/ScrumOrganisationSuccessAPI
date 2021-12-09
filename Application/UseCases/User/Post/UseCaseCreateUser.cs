using Application.UseCases.User.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.User;

namespace Application.UseCases.User.Post
{
    public class UseCaseCreateUser : IWriting<OutputDtoUser, InputDtoUser>
    {
        private readonly IUserRepository _userRepository;
        
        public UseCaseCreateUser(IUserRepository userRepository) {
            _userRepository = userRepository;
        }
        
        public OutputDtoUser Execute(InputDtoUser dto)
        {
            var userFromDto = Mapper.GetInstance().Map<Domain.User>(dto);
            
            var user = _userRepository.Create(userFromDto);
            
            return Mapper.GetInstance().Map<OutputDtoUser>(user);
        }
    }
}