using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Infrastructure.SqlServer.Utils;
using NotImplementedException = System.NotImplementedException;

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