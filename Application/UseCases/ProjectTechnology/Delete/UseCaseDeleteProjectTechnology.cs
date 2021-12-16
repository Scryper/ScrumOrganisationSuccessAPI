using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Project;
using Infrastructure.SqlServer.Repositories.ProjectTechnology;

namespace Application.UseCases.ProjectTechnology.Delete
{
    public class UseCaseDeleteProjectTechnology : IWritingMultipleKeys<bool,int,int>
    {
        private readonly IProjectTechnologyRepository _projectTechnologyRepository;

        public UseCaseDeleteProjectTechnology(IProjectTechnologyRepository projectTechnologyRepository)
        {
            _projectTechnologyRepository = projectTechnologyRepository;
        }


        public bool Execute(int idProject, int idTechnology)
        {
            return _projectTechnologyRepository.Delete(idProject, idTechnology);
        }
    }
}