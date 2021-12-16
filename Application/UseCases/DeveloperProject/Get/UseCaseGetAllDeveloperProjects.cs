using System.Collections.Generic;
using Application.UseCases.DeveloperProject.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.DeveloperProject;

namespace Application.UseCases.DeveloperProject.Get
{
    public class UseCaseGetAllDeveloperProjects : IQuery<List<OutputDtoDeveloperProject>>
    {
        private readonly IDeveloperProjectRepository _developerProjectRepository;

        public UseCaseGetAllDeveloperProjects(IDeveloperProjectRepository developerProjectRepository)
        {
            _developerProjectRepository = developerProjectRepository;
        }
        
        public List<OutputDtoDeveloperProject> Execute()
        {
            var developerProjectsFromDb = _developerProjectRepository.GetAll();

            return Mapper.GetInstance().Map<List<OutputDtoDeveloperProject>>(developerProjectsFromDb);
        }
    }
}