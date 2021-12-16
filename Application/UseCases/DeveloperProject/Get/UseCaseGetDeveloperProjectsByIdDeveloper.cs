using System.Collections.Generic;
using Application.UseCases.DeveloperProject.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.DeveloperProject;

namespace Application.UseCases.DeveloperProject.Get
{
    public class UseCaseGetDeveloperProjectsByIdDeveloper : IQueryFiltering<List<OutputDtoDeveloperProject>, int>
    {
        private readonly IDeveloperProjectRepository _developerProjectRepository;

        public UseCaseGetDeveloperProjectsByIdDeveloper(IDeveloperProjectRepository developerProjectRepository)
        {
            _developerProjectRepository = developerProjectRepository;
        }
        
        public List<OutputDtoDeveloperProject> Execute(int filter)
        {
            var developerProjectsFromDb = _developerProjectRepository.GetByIdDeveloper(filter);

            return Mapper.GetInstance().Map<List<OutputDtoDeveloperProject>>(developerProjectsFromDb);
        }
    }
}