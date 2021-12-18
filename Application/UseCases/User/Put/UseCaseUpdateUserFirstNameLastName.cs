using Application.UseCases.User.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.User;

namespace Application.UseCases.User.Put
{
    public class UseCaseUpdateUserFirstNameLastName : IWriting<bool, InputDtoUpdateUserFirstNameLastName>
    {
        private readonly IUserRepository _userRepository;

        public UseCaseUpdateUserFirstNameLastName(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public bool Execute(InputDtoUpdateUserFirstNameLastName data)
        {
            return _userRepository.UpdateFirstNameLastName(data.Id, data.InternUser.FirstName, data.InternUser.LastName);
        }
    }
}