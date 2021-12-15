using System.Collections.Generic;
using Application.UseCases.DeveloperProject.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.developer_project;

namespace Application.UseCases.DeveloperProject.Get
{
    public class UseCaseGetDeveloperProjectsByIdProject
    {
        private readonly IDeveloperProjectRepository _developerProjectRepository;

        public UseCaseGetDeveloperProjectsByIdProject(IDeveloperProjectRepository developerProjectRepository)
        {
            _developerProjectRepository = developerProjectRepository;
        }
        
        public List<OutputDtoDeveloperProject> Execute(int filter)
        {
            var developerProjectsFromDb = _developerProjectRepository.GetByIdProject(filter);

            return Mapper.GetInstance().Map<List<OutputDtoDeveloperProject>>(developerProjectsFromDb);
        }
    }
}