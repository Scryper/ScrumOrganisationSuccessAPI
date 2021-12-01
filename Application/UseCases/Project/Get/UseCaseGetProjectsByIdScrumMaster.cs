using System.Collections.Generic;
using Application.UseCases.Project.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Project;

namespace Application.UseCases.Project.Get
{
    public class UseCaseGetProjectsByIdScrumMaster : IQueryFiltering<List<OutputDtoProject>, int>
    {
        private readonly IProjectRepository _projectRepository;

        public UseCaseGetProjectsByIdScrumMaster(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }


        public List<OutputDtoProject> Execute(int filter)
        {
            var projects = _projectRepository.GetByIdScrumMaster(filter);

            return Mapper.GetInstance().Map<List<OutputDtoProject>>(projects);
        }
    }
}