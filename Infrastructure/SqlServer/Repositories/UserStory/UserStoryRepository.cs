using System.Collections.Generic;
using System.Data;
using System.Linq;
using Infrastructure.SqlServer.Utils;
using NotImplementedException = System.NotImplementedException;

namespace Infrastructure.SqlServer.Repositories.UserStory
{
    public partial class UserStoryRepository : IUserStoryRepository
    {
        private readonly IDomainFactory<Domain.UserStory> _userStoryFactory = new UserStoryFactory();
        
        // Get requests
        public List<Domain.UserStory> GetAll()
        {
            var userStories = new List<Domain.UserStory>();

            var command = Database.GetCommand(ReqGetAll);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            // Add all user stories
            while(reader.Read()) userStories.Add(_userStoryFactory.CreateFromSqlReader(reader));
            
            return userStories;
        }

        public List<Domain.UserStory> GetByIdProject(int idProject)
        {
            var userStories = new List<Domain.UserStory>();
            
            var command = Database.GetCommand(ReqGetByIdProject);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColIdProject, idProject);
            
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            // Add all user stories
            while(reader.Read()) userStories.Add(_userStoryFactory.CreateFromSqlReader(reader));
            
            return userStories;
        }

        public Domain.UserStory GetById(int id)
        {
            var command = Database.GetCommand(ReqGetById);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColId, id);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            // Return the user story if found, null if not
            return reader.Read() ? _userStoryFactory.CreateFromSqlReader(reader) : null;
        }

        public List<Domain.UserStory> GetByIdSprint(int idSprint)
        {
            var userStories = new List<Domain.UserStory>();
            
            var command = Database.GetCommand(ReqGetByIdSprint);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColIdSprint, idSprint);
            
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            // Add all user stories
            while(reader.Read()) userStories.Add(_userStoryFactory.CreateFromSqlReader(reader));
            
            return userStories;
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