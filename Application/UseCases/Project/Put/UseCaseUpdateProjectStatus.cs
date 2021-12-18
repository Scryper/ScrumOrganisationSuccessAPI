using Application.UseCases.Project.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Project;

namespace Application.UseCases.Project.Put
{
    public class UseCaseUpdateProjectStatus : IWriting<bool, InputDtoUpdateProjectStatus>
    {
        private readonly IProjectRepository _projectRepository;

        public UseCaseUpdateProjectStatus(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public bool Execute(InputDtoUpdateProjectStatus data)
        {
           ;return _projectRepository.UpdateStatus(data.Id, data.InternProject.Status);
        }
    }
}