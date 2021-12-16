using System.Collections.Generic;
using System.Data;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.SprintUserStory
{
    public partial class SprintUserStoryRepository : ISprintUserStoryRepository
    {
        private readonly IDomainFactory<Domain.SprintUserStory> _sprintUserStoryFactory = new SprintUserStoryFactory();

        // Get requests
        public List<Domain.SprintUserStory> GetAll()
        {
            var sprintUserStories = new List<Domain.SprintUserStory>();

            var command = Database.GetCommand(ReqGetAll);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            // Add all sprint links to user stories
            while(reader.Read()) sprintUserStories.Add(_sprintUserStoryFactory.CreateFromSqlReader(reader));

            return sprintUserStories;
        }

        // TODO : factorisation
        public List<Domain.SprintUserStory> GetByIdSprint(int idSprint)
        {
            var sprintUserStories = new List<Domain.SprintUserStory>();

            var command = Database.GetCommand(ReqGetByIdSprint);

            command.Parameters.AddWithValue("@" + ColIdSprint, idSprint);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            // Add all sprint links to user stories
            while(reader.Read()) sprintUserStories.Add(_sprintUserStoryFactory.CreateFromSqlReader(reader));

            return sprintUserStories;
        }

        // TODO : factorisation
        public List<Domain.SprintUserStory> GetByIdUserStory(int idUserStory)
        {
            var sprintUserStories = new List<Domain.SprintUserStory>();

            var command = Database.GetCommand(ReqGetByIdUserStory);

            command.Parameters.AddWithValue("@" + ColIdUserStory, idUserStory);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            // Add all sprint links to user stories
            while(reader.Read()) sprintUserStories.Add(_sprintUserStoryFactory.CreateFromSqlReader(reader));

            return sprintUserStories;
        }

        // Post requests
        public Domain.SprintUserStory Create(Domain.SprintUserStory sprintUserStory)
        {
            var command = Database.GetCommand(ReqCreate);

            command.Parameters.AddWithValue("@" + ColIdSprint, sprintUserStory.IdSprint);
            command.Parameters.AddWithValue("@" + ColIdUserStory, sprintUserStory.IdUserStory);

            command.ExecuteNonQuery();
            
            return new Domain.SprintUserStory
            {
                IdSprint = sprintUserStory.IdSprint,
                IdUserStory = sprintUserStory.IdUserStory
            };
        }

        // Delete requests
        public bool Delete(int idSprint, int idUserStory)
        {
            var command = Database.GetCommand(ReqDelete);

            command.Parameters.AddWithValue("@" + ColIdSprint, idSprint);
            command.Parameters.AddWithValue("@" + ColIdUserStory, idUserStory);

            return command.ExecuteNonQuery() > 0;
        }
    }
}