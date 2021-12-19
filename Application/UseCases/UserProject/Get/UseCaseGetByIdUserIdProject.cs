using Application.UseCases.UserProject.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.UserProject;

namespace Application.UseCases.UserProject.Get
{
    public class UseCaseGetByIdUserIdProject : IQueryFilteringTwoFilters<OutputDtoUserProject, int, int>
    {
        private readonly IUserProjectRepository _userProjectRepository;

        public UseCaseGetByIdUserIdProject(IUserProjectRepository userProjectRepository)
        {
            _userProjectRepository = userProjectRepository;
        }
        
        public OutputDtoUserProject Execute(int idDeveloper, int idProject)
        {
            var project = _userProjectRepository.GetByIdDeveloperIdProject(idDeveloper, idProject);

            return Mapper.GetInstance().Map<OutputDtoUserProject>(project);
        }
    }
}