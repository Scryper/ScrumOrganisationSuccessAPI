using Application.UseCases.Sprint.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Sprint;

namespace Application.UseCases.Sprint.Get
{
    public class UseCaseGetSprintById : IQueryFiltering<OutputDtoSprint, int>
    {
        private readonly ISprintRepository _sprintRepository;

        public UseCaseGetSprintById(ISprintRepository sprintRepository)
        {
            _sprintRepository = sprintRepository;
        }
        
        public OutputDtoSprint Execute(int filter)
        {
            var sprint = _sprintRepository.GetById(filter);

            return Mapper.GetInstance().Map<OutputDtoSprint>(sprint);
        }
    }
}