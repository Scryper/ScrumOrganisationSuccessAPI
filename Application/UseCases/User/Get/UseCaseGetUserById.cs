using Application.Services.User;
using Application.UseCases.User.Dtos;
using Application.UseCases.Utils;

namespace Application.UseCases.User.Get
{
    public class UseCaseGetUserById : IQueryFiltering<OutputDtoUser, int>
    {
        private readonly IUserService _userService;

        public UseCaseGetUserById(IUserService userService)
        {
            _userService = userService;
        }

        public OutputDtoUser Execute(int filter)
        {
            var user = _userService.GetById(filter);

            return Mapper.GetInstance().Map<OutputDtoUser>(user);
        }
    }
}