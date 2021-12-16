using Application.UseCases.Project.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Project;

namespace Application.UseCases.Project.Post
{
    public class UseCaseCreateProject : IWriting<OutputDtoProject, InputDtoProject>
    {
        private readonly IProjectRepository _projectRepository;

        public UseCaseCreateProject(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public OutputDtoProject Execute(InputDtoProject dto)
        {
            var projectFromDto = Mapper.GetInstance().Map<Domain.Project>(dto);

            var project = _projectRepository.Create(projectFromDto);

            return Mapper.GetInstance().Map<OutputDtoProject>(project);
        }
    }
}