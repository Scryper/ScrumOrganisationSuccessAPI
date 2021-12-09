using System.Collections.Generic;
using Application.UseCases.User.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.User;

namespace Application.UseCases.User.Get
{
    public class UseCaseGetAllUsers : IQuery<List<OutputDtoUser>>
    {
        private readonly IUserRepository _userRepository;

        public UseCaseGetAllUsers(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public List<OutputDtoUser> Execute()
        {
            var usersFromDb = _userRepository.GetAll();

            return Mapper.GetInstance().Map<List<OutputDtoUser>>(usersFromDb);
        }
    }
}