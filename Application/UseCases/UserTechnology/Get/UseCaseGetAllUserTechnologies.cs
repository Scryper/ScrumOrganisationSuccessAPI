using System.Collections.Generic;
using Application.UseCases.UserTechnology.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.UserTechnology;

namespace Application.UseCases.UserTechnology.Get
{
    public class UseCaseGetAllUserTechnologies : IQuery<List<OutputDtoUserTechnology>>
    {
        private readonly IUserTechnologyRepository _userTechnologyRepository;

        public UseCaseGetAllUserTechnologies(IUserTechnologyRepository userTechnologyRepository)
        {
            _userTechnologyRepository = userTechnologyRepository;
        }


        public List<OutputDtoUserTechnology> Execute()
        {
            var userTechnologies = _userTechnologyRepository.GetAll();

            return Mapper.GetInstance().Map<List<OutputDtoUserTechnology>>(userTechnologies);
        }
    }
}