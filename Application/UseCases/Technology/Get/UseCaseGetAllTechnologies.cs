using System.Collections.Generic;
using Application.UseCases.Technology.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Technology;

namespace Application.UseCases.Technology.Get
{
    public class UseCaseGetAllTechnologies : IQuery<List<OutputDtoTechnology>>
    {
        private readonly ITechnologyRepository _technologyRepository;

        public UseCaseGetAllTechnologies(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }


        public List<OutputDtoTechnology> Execute()
        {
            var technologiesFromDb = _technologyRepository.GetAll();

            return Mapper.GetInstance().Map<List<OutputDtoTechnology>>(technologiesFromDb);
        }
    }
}