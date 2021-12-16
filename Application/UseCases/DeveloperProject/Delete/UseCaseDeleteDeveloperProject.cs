using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.DeveloperProject;

namespace Application.UseCases.DeveloperProject.Delete
{
    public class UseCaseDeleteDeveloperProject : IWritingMultipleKeys<bool, int, int>
    {
        private readonly IDeveloperProjectRepository _developerProjectRepository;

        public UseCaseDeleteDeveloperProject(IDeveloperProjectRepository developerProjectRepository)
        {
            _developerProjectRepository = developerProjectRepository;
        }

        public bool Execute(int idDeveloper, int idProject)
        {
            return _developerProjectRepository.Delete(idDeveloper, idProject);
        }
    }
}