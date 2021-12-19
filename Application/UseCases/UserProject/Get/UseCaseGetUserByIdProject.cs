using System.Collections.Generic;
using Application.UseCases.UserProject.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.UserProject;

namespace Application.UseCases.UserProject.Get
{
    public class UseCaseGetUserByIdProject : IQueryFiltering<List<OutputDtoUserProject>, int>
    {
        private readonly IUserProjectRepository _userProjectRepository;

        public UseCaseGetUserByIdProject(IUserProjectRepository userProjectRepository)
        {
            _userProjectRepository = userProjectRepository;
        }

        public List<OutputDtoUserProject> Execute(int filter)
        {
            var developersFromDb = _userProjectRepository.GetDevsByIdProject(filter);

            return Mapper.GetInstance().Map<List<OutputDtoUserProject>>(developersFromDb);
        }
    }
}