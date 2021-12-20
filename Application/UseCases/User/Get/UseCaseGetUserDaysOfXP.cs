using Application.Services.User;
using Application.UseCases.Utils;

namespace Application.UseCases.User.Get
{
    public class UseCaseGetUserDaysOfXP : IQueryFiltering<int,int>
    {
        private IUserService _userService;

        public UseCaseGetUserDaysOfXP(IUserService userService)
        {
            _userService = userService;
        }


        public int Execute(int filter)
        {
            return _userService.ComputeDaysOfExperience(filter);
        }
    }
}