using Application.Security.Models;
using Application.Services.User;

namespace Application.UseCases.User.Post
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