using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Project;

namespace Application.UseCases.Project.Delete
{
    public class UseCaseDeleteProject : IWriting<bool, int>
    {
        private readonly IProjectRepository _projectRepository;

        public UseCaseDeleteProject(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public bool Execute(int data)
        {
            return _projectRepository.Delete(data);
        }
    }
}