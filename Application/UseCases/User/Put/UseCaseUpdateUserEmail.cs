using Application.UseCases.User.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.User;

namespace Application.UseCases.User.Put
{
    public class UseCaseUpdateUserEmail : IWriting<bool, InputDtoUpdateUserEmail>
    {
        private readonly IUserRepository _userRepository;

        public UseCaseUpdateUserEmail(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Execute(InputDtoUpdateUserEmail data)
        {
            return _userRepository.UpdateEmail(data.Id, data.InternUser.Email);
        }
    }
}