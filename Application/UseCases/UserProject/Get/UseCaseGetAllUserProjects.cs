using System.Collections.Generic;
using Application.UseCases.UserProject.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.UserProject;

namespace Application.UseCases.UserProject.Get
{
    public class UseCaseGetAllUserProjects : IQuery<List<OutputDtoUserProject>>
    {
        private readonly IUserProjectRepository _userProjectRepository;

        public UseCaseGetAllUserProjects(IUserProjectRepository userProjectRepository)
        {
            _userProjectRepository = userProjectRepository;
        }
        
        public List<OutputDtoUserProject> Execute()
        {
            var developerProjectsFromDb = _userProjectRepository.GetAll();

            return Mapper.GetInstance().Map<List<OutputDtoUserProject>>(developerProjectsFromDb);
        }
    }
}