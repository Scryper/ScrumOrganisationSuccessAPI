using Application.UseCases.DeveloperProject.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.developer_project;

namespace Application.UseCases.DeveloperProject.Post
{
    public class UseCaseCreateDeveloperProject : IWriting<OutputDtoDeveloperProject,InputDtoDeveloperProject>
    {
        private readonly IDeveloperProjectRepository _developerProjectRepository;

        public UseCaseCreateDeveloperProject(IDeveloperProjectRepository developerProjectRepository)
        {
            _developerProjectRepository = developerProjectRepository;
        }
        
        public OutputDtoDeveloperProject Execute(InputDtoDeveloperProject dto)
        {
            var developerProjectFromDto = Mapper.GetInstance().Map<Domain.DeveloperProject>(dto);

            var developerProject = _developerProjectRepository.Create(developerProjectFromDto);

            return Mapper.GetInstance().Map<OutputDtoDeveloperProject>(developerProject);
        }
    }
}