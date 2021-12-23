using System.Collections.Generic;
using Application.UseCases.UserTechnology.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.UserTechnology;

namespace Application.UseCases.UserTechnology.Get
{
    public class UseCaseGetUserTechnologyByIdTechnologyIdUser : IQueryFilteringTwoFilters<List<OutputDtoUserTechnology>,int,int>
    {
        private readonly IUserTechnologyRepository _userTechnologyRepository;

        public UseCaseGetUserTechnologyByIdTechnologyIdUser(IUserTechnologyRepository userTechnologyRepository)
        {
            _userTechnologyRepository = userTechnologyRepository;
        }
        
        public List<OutputDtoUserTechnology> Execute(int idTechnology, int idUser)
        {
            var userTechnology = _userTechnologyRepository.GetByIdTechnologyIdUser(idTechnology, idUser);
            
            return Mapper.GetInstance().Map<List<OutputDtoUserTechnology>>(userTechnology);
        }
    }
}