using Application.UseCases.ProjectTechnology.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.ProjectTechnology;

namespace Application.UseCases.ProjectTechnology.Post
{
    public class UseCaseCreateProjectTechnologies : IWriting<OutputDtoProjectTechnology,InputDtoProjectTechnology>
    {
        private readonly IProjectTechnologyRepository _projectTechnologyRepository;

        public UseCaseCreateProjectTechnologies(IProjectTechnologyRepository projectTechnologyRepository)
        {
            _projectTechnologyRepository = projectTechnologyRepository;
        }

        public OutputDtoProjectTechnology Execute(InputDtoProjectTechnology data)
        {
            var projectTechnologyFromDb = Mapper.GetInstance().Map<Domain.ProjectTechnology>(data);
            var projectTechnology = _projectTechnologyRepository.Create(projectTechnologyFromDb);
            
            return Mapper.GetInstance().Map<OutputDtoProjectTechnology>(projectTechnology);
        }
    }
}