using Application.UseCases.Technology.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Technology;

namespace Application.UseCases.Technology.Get
{
    public class UseCaseGetTechnologyByName : IQueryFiltering<OutputDtoTechnology, string>
    {
        private readonly ITechnologyRepository _technologyRepository;

        public UseCaseGetTechnologyByName(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }


        public OutputDtoTechnology Execute(string filter)
        {
            var technology = _technologyRepository.GetByName(filter);

            return Mapper.GetInstance().Map<OutputDtoTechnology>(technology);
        }
    }
}