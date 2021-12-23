using System.Collections.Generic;
using Application.UseCases.Project.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Project;

namespace Application.UseCases.Project.Get
{
    public class UseCaseGetActiveProjects : IQuery<List<OutputDtoProject>>
    {
        private readonly IProjectRepository _projectRepository;

        public UseCaseGetActiveProjects(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        
        public List<OutputDtoProject> Execute()
        {
            var projectsFromDb = _projectRepository.GetActiveProject();

            return Mapper.GetInstance().Map<List<OutputDtoProject>>(projectsFromDb);
        }
    }
 
}