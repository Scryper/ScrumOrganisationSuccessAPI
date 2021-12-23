using System.Collections.Generic;
using Application.UseCases.ProjectTechnology.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.ProjectTechnology;

namespace Application.UseCases.ProjectTechnology.Get
{
    public class UseCaseGetProjectTechnologiesByIdTechnology : IQueryFiltering<List<OutputDtoProjectTechnology>,int>
    {
        private readonly IProjectTechnologyRepository _projectTechnologyRepository;

        public UseCaseGetProjectTechnologiesByIdTechnology(IProjectTechnologyRepository projectTechnologyRepository)
        {
            _projectTechnologyRepository = projectTechnologyRepository;
        }


        public List<OutputDtoProjectTechnology> Execute(int filter)
        {
            var projectTechnology = _projectTechnologyRepository.getByIdTechnology(filter);
            
            return Mapper.GetInstance().Map<List<OutputDtoProjectTechnology>>(projectTechnology);
        }
    }
}