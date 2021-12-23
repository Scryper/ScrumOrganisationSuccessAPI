using System.Collections.Generic;
using Application.UseCases.Project.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Project;

namespace Application.UseCases.Project.Get
{
    public class UseCaseGetByIdUserActiveProject : IQueryFiltering<List<OutputDtoProject>, int>
    {
        private readonly IProjectRepository _projectRepository;

        public UseCaseGetByIdUserActiveProject(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        
        public List<OutputDtoProject> Execute(int filter)
        {
            var projectsFromDb = _projectRepository.GetActiveProjectByUser(filter);

            return Mapper.GetInstance().Map<List<OutputDtoProject>>(projectsFromDb);
        }
    }
}