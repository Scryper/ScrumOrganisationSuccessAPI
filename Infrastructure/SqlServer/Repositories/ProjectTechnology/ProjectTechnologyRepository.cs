using System.Collections.Generic;
using System.Data;
using System.Linq;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.ProjectTechnology
{
    public partial class ProjectTechnologyRepository : IProjectTechnologyRepository
    {
        private readonly IDomainFactory<Domain.ProjectTechnology> _projectTechnologyFactory = new ProjectTechnologyFactory();

        // Get requests
        public List<Domain.ProjectTechnology> GetAll()
        {
            var projectTechnologies = new List<Domain.ProjectTechnology>();
            
            var command = Database.GetCommand(ReqGetAll);
            
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            while(reader.Read()) projectTechnologies.Add(_projectTechnologyFactory.CreateFromSqlReader(reader));
            
            return projectTechnologies;
        }

        // Utils for GetActiveProjectByUser and GetProjectByIdUserNotFinishedIsLinked
        // Both return a list of projects, the only changing parameters are the request and the column on which 
        // the request base its verification
        private List<Domain.ProjectTechnology> GetByIdHelper(int id, string column, string request)
        {
            var projectTechnologies = new List<Domain.ProjectTechnology>();
            
            var command = Database.GetCommand(request);
            
            command.Parameters.AddWithValue("@" + column, id);
            
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            while(reader.Read()) projectTechnologies.Add(_projectTechnologyFactory.CreateFromSqlReader(reader));
            
            return projectTechnologies;
        }
        
        public List<Domain.ProjectTechnology> GetByIdProject(int idProject)
        {
            return GetByIdHelper(idProject, ColIdProject, ReqGetByIdProject);
        }

        public List<Domain.ProjectTechnology> getByIdTechnology(int idTechnology)
        {
            return GetByIdHelper(idTechnology, ColIdTechnology, ReqGetByIdTechnology);
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