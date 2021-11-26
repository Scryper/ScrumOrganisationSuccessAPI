using System.Runtime.CompilerServices;
using Application.UseCases.User.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.User;

namespace Application.UseCases.User.Put
{
    public class UseCaseUpdateUserPassword : IWriting<bool, InputDtoUpdateUserPassword>
    {
        private readonly IUserRepository _userRepository;

        public UseCaseUpdateUserPassword(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Execute(InputDtoUpdateUserPassword data)
        {
            return _userRepository.UpdatePassword(data.Id, data.InternUser.Password);
        }
    }
}