using System.Collections.Generic;
using Application.UseCases.ProjectTechnology.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.ProjectTechnology;

namespace Application.UseCases.ProjectTechnology.Get
{
    public class UseCaseGetAllProjectTechnologies : IQuery<List<OutputDtoProjectTechnology>>
    {
        private readonly IProjectTechnologyRepository _projectTechnologyRepository;

        public UseCaseGetAllProjectTechnologies(IProjectTechnologyRepository projectTechnologyRepository)
        {
            _projectTechnologyRepository = projectTechnologyRepository;
        }
        
        public List<OutputDtoProjectTechnology> Execute()
        {
            var projectTechnologies = _projectTechnologyRepository.GetAll();

            return Mapper.GetInstance().Map<List<OutputDtoProjectTechnology>>(projectTechnologies);
        }
    }
}