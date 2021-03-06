using System.Collections.Generic;
using Application.UseCases.User.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.User;

namespace Application.UseCases.User.Get
{
    public class UseCaseGetUsersByIdProjectIsWorking : IQueryFiltering<List<OutputDtoUser>, int>
    {
        private readonly IUserRepository _userRepository;

        public UseCaseGetUsersByIdProjectIsWorking(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<OutputDtoUser> Execute(int filter)
        {
            var users = _userRepository.GetByIdProjectIsWorking(filter);

            return Mapper.GetInstance().Map<List<OutputDtoUser>>(users);
        }
    }
}