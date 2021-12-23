using System.Collections.Generic;
using System.Linq;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.ProjectTechnology
{
    public partial class ProjectTechnologyRepository : IProjectTechnologyRepository
    {
        private readonly IDomainFactory<Domain.ProjectTechnology> _projectTechnologyFactory = new ProjectTechnologyFactory();
        private readonly RequestHelper<Domain.ProjectTechnology> _requestHelper = new RequestHelper<Domain.ProjectTechnology>();

        // Get requests
        public List<Domain.ProjectTechnology> GetAll()
        {
            return _requestHelper.GetAll(ReqGetAll, _projectTechnologyFactory);
        }

        public List<Domain.ProjectTechnology> GetByIdProject(int idProject)
        {
            return _requestHelper.GetByIdHelper(idProject, ColIdProject, ReqGetByIdProject, _projectTechnologyFactory);
        }

        public List<Domain.ProjectTechnology> getByIdTechnology(int idTechnology)
        {
            return _requestHelper.GetByIdHelper(idTechnology, ColIdTechnology, ReqGetByIdTechnology, _projectTechnologyFactory);
        }

        // Post requests
        public Domain.ProjectTechnology Create(Domain.ProjectTechnology projectTechnology)
        {
            if (Exists(projectTechnology)) return null;
            
            var command = Database.GetCommand(ReqCreate);

            command.Parameters.AddWithValue("@" + ColIdProject, projectTechnology.IdProject);
            command.Parameters.AddWithValue("@" + ColIdTechnology, projectTechnology.IdTechnology);

            command.ExecuteNonQuery();
            
            return new Domain.ProjectTechnology
            {
                IdTechnology = projectTechnology.IdTechnology,
                IdProject = projectTechnology.IdProject
            };
        }
        
        // Utils for post request
        private bool Exists(Domain.ProjectTechnology projectTechnology)
        {
            var projectTechnologies = GetAll();
            return Enumerable.Contains(projectTechnologies, projectTechnology);
        }

        // Delete requests
        public bool Delete(int idProject, int idTechnology)
        {
            var command = Database.GetCommand(ReqDelete);

            command.Parameters.AddWithValue("@" + ColIdProject, idProject);
            command.Parameters.AddWithValue("@" + ColIdTechnology, idTechnology);

            return command.ExecuteNonQuery() > 0;
        }
    }
}