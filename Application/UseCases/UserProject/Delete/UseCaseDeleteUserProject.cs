using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.UserProject;

namespace Application.UseCases.UserProject.Delete
{
    public class UseCaseDeleteUserProject : IWritingMultipleKeys<bool, int, int>
    {
        private readonly IUserProjectRepository _userProjectRepository;

        public UseCaseDeleteUserProject(IUserProjectRepository userProjectRepository)
        {
            _userProjectRepository = userProjectRepository;
        }

        public bool Execute(int idDeveloper, int idProject)
        {
            return _userProjectRepository.Delete(idDeveloper, idProject);
        }
    }
}