using Application.UseCases.DeveloperProject.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.DeveloperProject;

namespace Application.UseCases.DeveloperProject.Put
{
    public class UseCaseUpdateDeveloperProject : IWriting<bool, InputDtoUpdateDeveloperProject>
    {
        private readonly IDeveloperProjectRepository _developerProjectRepository;

        public UseCaseUpdateDeveloperProject(IDeveloperProjectRepository developerProjectRepository)
        {
            _developerProjectRepository = developerProjectRepository;
        }
        
        public bool Execute(InputDtoUpdateDeveloperProject dto)
        {
            return _developerProjectRepository.Update(dto.IdDeveloper, dto.IdProject, dto.InternIsApply.IsAppliance);
        }
    }
}