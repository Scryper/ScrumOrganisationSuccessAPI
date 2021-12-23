using System.Collections.Generic;
using Application.UseCases.UserTechnology.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.UserTechnology;

namespace Application.UseCases.UserTechnology.Get
{
    public class UseCaseGetUserTechnologyByIdTechnology : IQueryFiltering<List<OutputDtoUserTechnology>,int>
    {
        private readonly IUserTechnologyRepository _userTechnologyRepository;

        public UseCaseGetUserTechnologyByIdTechnology(IUserTechnologyRepository userTechnologyRepository)
        {
            _userTechnologyRepository = userTechnologyRepository;
        }


        public List<OutputDtoUserTechnology> Execute(int filter)
        {
            var userTechnology = _userTechnologyRepository.GetByIdTechnology(filter);
        
            return Mapper.GetInstance().Map<List<OutputDtoUserTechnology>>(userTechnology);
        }
    }
}