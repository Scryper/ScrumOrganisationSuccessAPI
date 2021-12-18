using System.Collections.Generic;
using Application.UseCases.DeveloperProject.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.DeveloperProject;

namespace Application.UseCases.DeveloperProject.Get
{
    public class UseCaseGetDeveloperProjectByIdDeveloperIfIsWorking : IQueryFiltering<List<OutputDtoDeveloperProject>, int>
    {
        
        private readonly IDeveloperProjectRepository _developerProjectRepository;

        public UseCaseGetDeveloperProjectByIdDeveloperIfIsWorking(IDeveloperProjectRepository developerProjectRepository)
        {
            _developerProjectRepository = developerProjectRepository;
        }
        
        public List<OutputDtoDeveloperProject> Execute(int filter)
        {
            var developerProjectsFromDb = _developerProjectRepository.GetByIdDeveloperifIsWorking(filter);

            return Mapper.GetInstance().Map<List<OutputDtoDeveloperProject>>(developerProjectsFromDb);
        }
    }
}