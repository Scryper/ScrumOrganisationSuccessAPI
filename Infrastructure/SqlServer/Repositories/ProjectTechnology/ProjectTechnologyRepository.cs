using System.Collections.Generic;
using System.Data;
using Infrastructure.SqlServer.Utils;
using NotImplementedException = System.NotImplementedException;

namespace Infrastructure.SqlServer.Repositories.ProjectTechnology
{
    public partial class ProjectTechnologyRepository : IProjectTechnologyRepository
    {
        private readonly IDomainFactory<Domain.ProjectTechnology> _projectTechnologyFactory = new ProjectTechnologyFactory();

        public List<Domain.ProjectTechnology> GetAll()
        {
            var projectTechnologies = new List<Domain.ProjectTechnology>();
            var command = Database.GetCommand(ReqGetAll);
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            while(reader.Read()) projectTechnologies.Add(_projectTechnologyFactory.CreateFromSqlReader(reader));
            
            return projectTechnologies;
        }

        public List<Domain.ProjectTechnology> GetByProjectId(int projectId)
        {
            var projectTechnologies = new List<Domain.ProjectTechnology>();
            var command = Database.GetCommand(ReqGetByIdProject);
            command.Parameters.AddWithValue("@" + ColIdProject,projectId);
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            while(reader.Read()) projectTechnologies.Add(_projectTechnologyFactory.CreateFromSqlReader(reader));
            
            return projectTechnologies;
        }

        public List<Domain.ProjectTechnology> getByTechnologyId(int technologyId)
        {
            var projectTechnologies = new List<Domain.ProjectTechnology>();
            var command = Database.GetCommand(ReqGetByIdTechnology);
            command.Parameters.AddWithValue("@" + ColIdTechnology,technologyId);
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            while(reader.Read()) projectTechnologies.Add(_projectTechnologyFactory.CreateFromSqlReader(reader));
            
            return projectTechnologies;
        }

        public Domain.ProjectTechnology Create(Domain.ProjectTechnology projectTechnology)
        {
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

        public bool Delete(int idProject, int idTechnology)
        {
            var command = Database.GetCommand(ReqDelete);

            command.Parameters.AddWithValue("@" + ColIdProject, idProject);
            command.Parameters.AddWithValue("@" + ColIdTechnology, idTechnology);

            return command.ExecuteNonQuery() > 0;
        }
    }
}