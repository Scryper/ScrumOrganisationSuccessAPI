using Application.UseCases.User.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.User;

namespace Application.UseCases.User.Put
{
    public class UseCaseUpdateUserPseudo : IWriting<bool, InputDtoUpdateUserPseudo>
    {
        private readonly IUserRepository _userRepository;

        public UseCaseUpdateUserPseudo(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Execute(InputDtoUpdateUserPseudo data)
        {
            return _userRepository.UpdatePseudo(data.Id, data.InternUser.Pseudo);
        }
    }
}