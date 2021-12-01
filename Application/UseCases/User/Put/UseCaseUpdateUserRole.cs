using Application.UseCases.User.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.User;

namespace Application.UseCases.User.Put
{
    public class UseCaseUpdateUserRole : IWriting<bool, InputDtoUpdateUserRole>
    {
        private readonly IUserRepository _userRepository;

        public UseCaseUpdateUserRole(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public bool Execute(InputDtoUpdateUserRole data)
        {
            return _userRepository.UpdateRole(data.Id, data.InternUser.Role);
        }
    }
}