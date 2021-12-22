using System.Collections.Generic;
using Application.UseCases.Sprint.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Sprint;

namespace Application.UseCases.Sprint.Get
{
    public class UseCaseGetAllSprints : IQuery<List<OutputDtoSprint>>
    {
        private readonly ISprintRepository _sprintRepository;

        public UseCaseGetAllSprints(ISprintRepository sprintRepository)
        {
            _sprintRepository = sprintRepository;
        }
        
        public List<OutputDtoSprint> Execute()
        {
            var sprintsFromDb = _sprintRepository.GetAll();

            return Mapper.GetInstance().Map<List<OutputDtoSprint>>(sprintsFromDb);
        }
    }
}