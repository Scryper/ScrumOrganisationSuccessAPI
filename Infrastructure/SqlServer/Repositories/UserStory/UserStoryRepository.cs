using System.Collections.Generic;
using System.Data;
using System.Linq;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.UserStory
{
    public partial class UserStoryRepository : IUserStoryRepository
    {
        private readonly IDomainFactory<Domain.UserStory> _userStoryFactory = new UserStoryFactory();
        private readonly RequestHelper<Domain.UserStory> _requestHelper = new RequestHelper<Domain.UserStory>();
        
        // Get requests
        public List<Domain.UserStory> GetAll()
        {
            return _requestHelper.GetAll(ReqGetAll, _userStoryFactory);
        }

        public List<Domain.UserStory> GetByIdProject(int idProject)
        {
            return _requestHelper.GetByIdHelper(idProject, ColIdProject, ReqGetByIdProject, _userStoryFactory);
        }

        public List<Domain.UserStory> GetByIdSprint(int idSprint)
        {
            return _requestHelper.GetByIdHelper(idSprint, ColIdSprint, ReqGetByIdSprint, _userStoryFactory);
        }
        
        public Domain.UserStory GetById(int id)
        {
            return _requestHelper.GetById(id, ColId, ReqGetById, _userStoryFactory);
        }

        // Post requests
        public Domain.UserStory Create(Domain.UserStory userStory)
        {
            if (Exists(userStory)) return null;
            
            var command = Database.GetCommand(ReqCreate);

            command.Parameters.AddWithValue("@" + ColIdProject, userStory.IdProject);
            command.Parameters.AddWithValue("@" + ColName, userStory.Name);
            command.Parameters.AddWithValue("@" + ColDescription, userStory.Description);
            command.Parameters.AddWithValue("@" + ColPriority, userStory.Priority);
            
            return new Domain.UserStory
            {
                Id = (int) command.ExecuteScalar(),
                Name = userStory.Name,
                Description = userStory.Description,
                IdProject = userStory.IdProject,
                Priority = userStory.Priority
            };
        }
        
        // Utils for post and update request
        private bool Exists(Domain.UserStory userStory)
        {
            var userStories = GetAll();
            return Enumerable.Contains(userStories, userStory);
        }

        private bool ExistsInProject(Domain.UserStory userStory)
        {
            var userStories = GetByIdProject(userStory.IdProject);
            return Enumerable.Contains(userStories, userStory);
        }

        // Post request
        public bool Update(int id, int idProject, string name, string description, int priority)
        {
            var userStory = new Domain.UserStory
            {
                Description = description,
                Id = 0,
                Name = name,
                Priority = priority,
                IdProject = idProject
            };

            if (ExistsInProject(userStory)) return false;
            
            var command = Database.GetCommand(ReqUpdateUserStory);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColId, id);
            command.Parameters.AddWithValue("@" + ColName, name);
            command.Parameters.AddWithValue("@" + ColDescription, description);
            command.Parameters.AddWithValue("@" + ColPriority, priority);

            return command.ExecuteNonQuery() > 0;
        }

        // Delete requests
        public bool Delete(int id)
        {
            var command = Database.GetCommand(ReqDeleteById);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColId, id);
            
            return command.ExecuteNonQuery() > 0;
        }
    }
}