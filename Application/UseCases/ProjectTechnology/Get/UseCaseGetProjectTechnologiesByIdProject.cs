using System.Collections.Generic;
using Application.UseCases.ProjectTechnology.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.ProjectTechnology;

namespace Application.UseCases.ProjectTechnology.Get
{
    public class UseCaseGetProjectTechnologiesByIdProject : IQueryFiltering<List<OutputDtoProjectTechnology>,int>
    {
        private readonly IProjectTechnologyRepository _projectTechnologyRepository;

        public UseCaseGetProjectTechnologiesByIdProject(IProjectTechnologyRepository projectTechnologyRepository)
        {
            _projectTechnologyRepository = projectTechnologyRepository;
        }

        public List<OutputDtoProjectTechnology> Execute(int filter)
        {
            var projectTechnology = _projectTechnologyRepository.GetByIdProject(filter);

            return Mapper.GetInstance().Map<List<OutputDtoProjectTechnology>>(projectTechnology);
        }
    }
}