using System.Collections.Generic;
using Application.UseCases.Project.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Project;

namespace Application.UseCases.Project
{
    public class UseCaseGetAllProjects : IQuery<List<OutputDtoProject>>
    {
        private readonly IProjectRepository _projectRepository;

        public UseCaseGetAllProjects(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        
        public List<OutputDtoProject> Execute()
        {
            var projectsFromDb = _projectRepository.GetAll();

            return Mapper.GetInstance().Map<List<OutputDtoProject>>(projectsFromDb);
        }
    }
}