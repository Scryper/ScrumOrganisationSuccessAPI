using Application.UseCases.User.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.User;

namespace Application.UseCases.User.Get
{
    public class UseCaseGetUserByEmail : IQueryFiltering<OutputDtoUser, string>
    {
        private readonly IUserRepository _userRepository;

        public UseCaseGetUserByEmail(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public OutputDtoUser Execute(string filter)
        {
            var user = _userRepository.GetByEmail(filter);

            return Mapper.GetInstance().Map<OutputDtoUser>(user);
        }
    }
}