using Application.UseCases.UserProject.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.DeveloperProject;
using Infrastructure.SqlServer.Repositories.UserProject;

namespace Application.UseCases.DeveloperProject.Post
{
    public class UseCaseCreateDeveloperProject : IWriting<OutputDtoUserProject,InputDtoUserProject>
    {
        private readonly IUserProjectRepository _userProjectRepository;

        public UseCaseCreateDeveloperProject(IUserProjectRepository userProjectRepository)
        {
            _userProjectRepository = userProjectRepository;
        }
        
        public OutputDtoUserProject Execute(InputDtoUserProject dto)
        {
            var developerProjectFromDto = Mapper.GetInstance().Map<Domain.UserProject>(dto);

            var developerProject = _userProjectRepository.Create(developerProjectFromDto);

            return Mapper.GetInstance().Map<OutputDtoUserProject>(developerProject);
        }
    }
}