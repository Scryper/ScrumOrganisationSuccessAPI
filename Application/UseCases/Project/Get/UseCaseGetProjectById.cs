using Application.UseCases.Project.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Project;

namespace Application.UseCases.Project.Get
{
    public class UseCaseGetProjectById : IQueryFiltering<OutputDtoProject, int>
    {
        private readonly IProjectRepository _projectRepository;

        public UseCaseGetProjectById(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        
        public OutputDtoProject Execute(int filter)
        {
            var project = _projectRepository.GetById(filter);

            return Mapper.GetInstance().Map<OutputDtoProject>(project);
        }
    }
}