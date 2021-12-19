using System.Collections.Generic;
using Application.UseCases.UserProject.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.UserProject;

namespace Application.UseCases.UserProject.Get
{
    public class UseCaseGetUserProjectsByIdDeveloperIsAppliance : IQueryFiltering<List<OutputDtoUserProject>,int>
    {
        private readonly IUserProjectRepository _userProjectRepository;

        public UseCaseGetUserProjectsByIdDeveloperIsAppliance(IUserProjectRepository userProjectRepository)
        {
            _userProjectRepository = userProjectRepository;
        }
        
        public List<OutputDtoUserProject> Execute(int filter)
        {
            var project = _userProjectRepository.GetByIdDeveloperIsAppliance(filter);

            return Mapper.GetInstance().Map<List<OutputDtoUserProject>>(project);
        }
    }
}