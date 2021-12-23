using System.Collections.Generic;
using Application.Services.Sprint;
using Application.UseCases.Sprint.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Sprint;

namespace Application.UseCases.Sprint.Get
{
    public class UseCaseGetSprintsByIdProject : IQueryFiltering<List<OutputDtoSprint>, int>
    {
        private readonly ISprintService _sprintService;

        public UseCaseGetSprintsByIdProject(ISprintService sprintService)
        {
            _sprintService = sprintService;
        }

        public List<OutputDtoSprint> Execute(int filter)
        {
            var sprints = _sprintService.GetByIdProject(filter);

            return Mapper.GetInstance().Map<List<OutputDtoSprint>>(sprints);
        }
    }
}