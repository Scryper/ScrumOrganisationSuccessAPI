using Application.UseCases.Technology.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Technology;

namespace Application.UseCases.Technology.Get
{
    public class UseCaseGetTechnologyById : IQueryFiltering<OutputDtoTechnology, int>
    {
        private readonly ITechnologyRepository _technologyRepository;

        public UseCaseGetTechnologyById(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }


        public OutputDtoTechnology Execute(int filter)
        {
            var technology = _technologyRepository.GetById(filter);

            return Mapper.GetInstance().Map<OutputDtoTechnology>(technology);
        }
    }
}