using System.Collections.Generic;
using System.Data;
using System.Linq;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.Sprint
{
    public partial class SprintRepository : ISprintRepository
    {
        private readonly IDomainFactory<Domain.Sprint> _sprintFactory = new SprintFactory();
        private readonly RequestHelper<Domain.Sprint> _requestHelper = new RequestHelper<Domain.Sprint>();

        // Get requests
        public List<Domain.Sprint> GetAll()
        {
            return _requestHelper.GetAll(ReqGetAll, _sprintFactory);
        }

        public List<Domain.Sprint> GetByIdProject(int idProject)
        {
            return _requestHelper.GetByIdHelper(idProject, ColIdProject, ReqGetByIdProject, _sprintFactory);
        }

        public Domain.Sprint GetById(int id)
        {
            return _requestHelper.GetById(id, ColId, ReqGetById, _sprintFactory);
        }

        // Post requests
        public Domain.Sprint Create(Domain.Sprint sprint)
        {
            if (Exists(sprint)) return null;
            
            var command = Database.GetCommand(ReqCreate);

            command.Parameters.AddWithValue("@" + ColIdProject, sprint.IdProject);
            command.Parameters.AddWithValue("@" + ColSprintNumber, sprint.SprintNumber);
            command.Parameters.AddWithValue("@" + ColDeadline, sprint.Deadline);
            command.Parameters.AddWithValue("@" + ColStartDate, sprint.StartDate);
            command.Parameters.AddWithValue("@" + ColDescription, sprint.Description);

            return new Domain.Sprint
            {
                Id = (int) command.ExecuteScalar(),
                SprintNumber = sprint.SprintNumber,
                IdProject = sprint.IdProject,
                Deadline = sprint.Deadline,
                StartDate = sprint.StartDate,
                Description = sprint.Description
            };
        }
        
        // Utils for post request
        private bool Exists(Domain.Sprint sprint)
        {
            var sprints = GetAll();
            return Enumerable.Contains(sprints, sprint);
        }
    }
}