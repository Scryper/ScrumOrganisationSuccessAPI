using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.User;

namespace Application.UseCases.User.Delete
{
    public class UseCaseDeleteUser : IWriting<bool, int>
    {
        private readonly IUserRepository _userRepository;

        public UseCaseDeleteUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public bool Execute(int data)
        {
            return _userRepository.Delete(data);
        }
    }
}