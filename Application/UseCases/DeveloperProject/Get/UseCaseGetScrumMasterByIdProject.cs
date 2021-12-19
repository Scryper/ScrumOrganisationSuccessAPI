using System.Collections.Generic;
using Application.UseCases.DeveloperProject.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.DeveloperProject;

namespace Application.UseCases.DeveloperProject.Get
{
    public class UseCaseGetScrumMasterByIdProject: IQueryFiltering<List<OutputDtoDeveloperProjectIdDeveloper>,int>
    {
        private readonly IDeveloperProjectRepository _developerProjectRepository;

        public UseCaseGetScrumMasterByIdProject(IDeveloperProjectRepository developerProjectRepository)
        {
            _developerProjectRepository = developerProjectRepository;
        }
        
        
        public List<OutputDtoDeveloperProjectIdDeveloper> Execute(int filter)
        {
            var developerssFromDb = _developerProjectRepository.GetScrumMasterByIdProject(filter);

            return Mapper.GetInstance().Map<List<OutputDtoDeveloperProjectIdDeveloper>>(developerssFromDb);
        }
    }
}