using Application.Security.Models;
using Application.Services.User;
using WebAPI.Security.Models;

namespace Application.UseCases.User
{
    public class UseCaseAuthenticateUser
    {
        private readonly IUserService _userService;

        public UseCaseAuthenticateUser(IUserService userService)
        {
            _userService = userService;
        }
        
        public AuthenticateResponse Execute(AuthenticateRequest model)
        {
            return _userService.Authenticate(model);
        }
    }
}