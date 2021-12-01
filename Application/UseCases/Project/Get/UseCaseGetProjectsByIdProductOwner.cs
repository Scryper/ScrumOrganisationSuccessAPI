using System.Collections.Generic;
using Application.UseCases.Project.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Project;

namespace Application.UseCases.Project.Get
{
    public class UseCaseGetProjectsByIdProductOwner : IQueryFiltering<List<OutputDtoProject>, int>
    {
        private readonly IProjectRepository _projectRepository;

        public UseCaseGetProjectsByIdProductOwner(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public List<OutputDtoProject> Execute(int filter)
        {
            var projects = _projectRepository.GetByIdProductOwner(filter);

            return Mapper.GetInstance().Map<List<OutputDtoProject>>(projects);
        }
    }
}