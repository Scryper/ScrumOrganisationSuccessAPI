using Application.UseCases.UserProject.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.DeveloperProject;
using Infrastructure.SqlServer.Repositories.UserProject;

namespace Application.UseCases.DeveloperProject.Put
{
    public class UseCaseUpdateDeveloperProject : IWriting<bool, InputDtoUpdateUserProject>
    {
        private readonly IUserProjectRepository _userProjectRepository;

        public UseCaseUpdateDeveloperProject(IUserProjectRepository userProjectRepository)
        {
            _userProjectRepository = userProjectRepository;
        }
        
        public bool Execute(InputDtoUpdateUserProject dto)
        {
            return _userProjectRepository.Update(dto.IdDeveloper, dto.IdProject, dto.InternIsApply.IsAppliance);
        }
    }
}