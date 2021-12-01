using System.Collections.Generic;
using Application.UseCases.Sprint.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Sprint;

namespace Application.UseCases.Sprint.Get
{
    public class UseCaseGetSprintsByIdProject : IQueryFiltering<List<OutputDtoSprint>, int>
    {
        private readonly ISprintRepository _sprintRepository;

        public UseCaseGetSprintsByIdProject(ISprintRepository sprintRepository)
        {
            _sprintRepository = sprintRepository;
        }

        public List<OutputDtoSprint> Execute(int filter)
        {
            var sprints = _sprintRepository.GetByIdProject(filter);

            return Mapper.GetInstance().Map<List<OutputDtoSprint>>(sprints);
        }
    }
}