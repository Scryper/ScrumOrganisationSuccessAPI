using Application.UseCases.Project.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Project;

namespace Application.UseCases.Project.Get
{
    public class UseCaseGetProjectByName : IQueryFiltering<OutputDtoProject, string>
    {
        private readonly IProjectRepository _projectRepository;

        public UseCaseGetProjectByName(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public OutputDtoProject Execute(string filter)
        {
            var project = _projectRepository.GetByName(filter);

            return Mapper.GetInstance().Map<OutputDtoProject>(project);
        }
    }
}