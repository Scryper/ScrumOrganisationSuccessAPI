using System.Collections.Generic;
using Application.UseCases.UserTechnology.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.UserTechnology;

namespace Application.UseCases.UserTechnology.Get
{
    public class UseCaseGetUserTechnologyByIdUser : IQueryFiltering<List<OutputDtoUserTechnology>,int>
    {
        private readonly IUserTechnologyRepository _userTechnologyRepository;

        public UseCaseGetUserTechnologyByIdUser(IUserTechnologyRepository userTechnologyRepository)
        {
            _userTechnologyRepository = userTechnologyRepository;
        }


        public List<OutputDtoUserTechnology> Execute(int filter)
        {
            var userTechnology = _userTechnologyRepository.GetByIdUser(filter);
            
            return Mapper.GetInstance().Map<List<OutputDtoUserTechnology>>(userTechnology);
        }
    }
}