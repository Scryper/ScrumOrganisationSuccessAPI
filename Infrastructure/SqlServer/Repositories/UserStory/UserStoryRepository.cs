using System.Collections.Generic;
using System.Data;
using Infrastructure.SqlServer.Utils;

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

        public List<Domain.UserStory> GetByIdSprint(int idSprint)
        {
            var userStories = new List<Domain.UserStory>();
            
            var command = Database.GetCommand(ReqGetByIdSprint);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColId, idSprint);
            
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
            command.Parameters.AddWithValue("@" + ColId, idProject);
            
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

        // Post requests
        public Domain.UserStory Create(Domain.UserStory userStory)
        {
            var command = Database.GetCommand(ReqCreate);

            command.Parameters.AddWithValue("@" + ColName, userStory.Name);
            command.Parameters.AddWithValue("@" + ColDescription, userStory.Description);
            command.Parameters.AddWithValue("@" + ColIsDone, userStory.IsDone);
            command.Parameters.AddWithValue("@" + ColIdProject, userStory.IdProject);
            
            return new Domain.UserStory
            {
                Id = (int) command.ExecuteScalar(),
                Name = userStory.Name,
                Description = userStory.Description,
                IsDone = userStory.IsDone,
                IdProject = userStory.IdProject
            };
        }
        
        // Put requests
        public bool UpdateIsDone(int id, bool isDone)
        {
            var command = Database.GetCommand(ReqUpdateIsDone);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColId, id);
            command.Parameters.AddWithValue("@" + ColIsDone, isDone);
            
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