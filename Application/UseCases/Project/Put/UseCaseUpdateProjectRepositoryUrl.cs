using Application.UseCases.Project.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Project;

namespace Application.UseCases.Project.Put
{
    public class UseCaseUpdateProjectRepositoryUrl : IWriting<bool, InputDtoUpdateProjectRepositoryUrl>
    {
        private readonly IProjectRepository _projectRepository;

        public UseCaseUpdateProjectRepositoryUrl(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        
        public bool Execute(InputDtoUpdateProjectRepositoryUrl data)
        {
            return _projectRepository.UpdateRepositoryUrl(data.Id, data.InternProject.RepositoryUrl);
        }
    }
}