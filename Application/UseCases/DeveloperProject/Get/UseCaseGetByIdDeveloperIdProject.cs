using Application.UseCases.DeveloperProject.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.DeveloperProject;

namespace Application.UseCases.DeveloperProject.Get
{
    public class UseCaseGetByIdDeveloperIdProject : IQueryFilteringTwoFilters<OutputDtoDeveloperProject, int,int>
    {
        private readonly IDeveloperProjectRepository _developerProjectRepository;

        public UseCaseGetByIdDeveloperIdProject(IDeveloperProjectRepository developerProjectRepository)
        {
            _developerProjectRepository = developerProjectRepository;
        }
        
        public OutputDtoDeveloperProject Execute(int idDeveloper, int idProject)
        {
            var project = _developerProjectRepository.GetByIdDeveloperIdProject(idDeveloper, idProject);

            return Mapper.GetInstance().Map<OutputDtoDeveloperProject>(project);
        }
    }
}