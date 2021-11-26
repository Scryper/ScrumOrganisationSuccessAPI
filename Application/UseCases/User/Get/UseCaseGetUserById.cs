using Application.UseCases.User.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.User;

namespace Application.UseCases.User.Get
{
    public class UseCaseGetUserById : IQueryFiltering<OutputDtoUser, int>
    {
        private readonly IUserRepository _userRepository;

        public UseCaseGetUserById(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public OutputDtoUser Execute(int filter)
        {
            var user = _userRepository.GetById(filter);

            return Mapper.GetInstance().Map<OutputDtoUser>(user);
        }
    }
}