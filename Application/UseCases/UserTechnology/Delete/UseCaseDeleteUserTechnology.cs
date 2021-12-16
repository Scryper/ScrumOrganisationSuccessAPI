using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.UserTechnology;

namespace Application.UseCases.UserTechnology.Delete
{
    public class UseCaseDeleteUserTechnology :IWritingMultipleKeys<bool,int, int>
    {
        private readonly IUserTechnologyRepository _userTechnologyRepository;

        public UseCaseDeleteUserTechnology(IUserTechnologyRepository userTechnologyRepository)
        {
            _userTechnologyRepository = userTechnologyRepository;
        }
        
        
        public bool Execute(int idUser, int idTechnology)
        {
            return _userTechnologyRepository.Delete(idUser, idTechnology);
        }
    }
}