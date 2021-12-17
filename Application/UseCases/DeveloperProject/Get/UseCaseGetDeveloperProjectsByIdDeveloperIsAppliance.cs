using System.Collections.Generic;
using Application.UseCases.DeveloperProject.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.DeveloperProject;

namespace Application.UseCases.DeveloperProject.Get
{
    public class UseCaseGetDeveloperProjectsByIdDeveloperIsAppliance : IQueryFiltering<List<OutputDtoDeveloperProject>,int>
    {
        private readonly IDeveloperProjectRepository _developerProjectRepository;

        public UseCaseGetDeveloperProjectsByIdDeveloperIsAppliance(IDeveloperProjectRepository developerProjectRepository)
        {
            _developerProjectRepository = developerProjectRepository;
        }
        
        public List<OutputDtoDeveloperProject> Execute(int filter)
        {
            var project = _developerProjectRepository.GetByIdDeveloperIsAppliance(filter);

            return Mapper.GetInstance().Map<List<OutputDtoDeveloperProject>>(project);
        }
    }
}