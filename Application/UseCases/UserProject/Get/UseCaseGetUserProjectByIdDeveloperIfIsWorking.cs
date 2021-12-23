using System.Collections.Generic;
using Application.UseCases.UserProject.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.UserProject;

namespace Application.UseCases.UserProject.Get
{
    public class UseCaseGetUserProjectByIdDeveloperIfIsWorking : IQueryFiltering<List<OutputDtoUserProject>, int>
    {
        
        private readonly IUserProjectRepository _userProjectRepository;

        public UseCaseGetUserProjectByIdDeveloperIfIsWorking(IUserProjectRepository userProjectRepository)
        {
            _userProjectRepository = userProjectRepository;
        }
        
        public List<OutputDtoUserProject> Execute(int filter)
        {
            var developerProjectsFromDb = _userProjectRepository.GetByIdDeveloperIfIsWorking(filter);

            return Mapper.GetInstance().Map<List<OutputDtoUserProject>>(developerProjectsFromDb);
        }
    }
}