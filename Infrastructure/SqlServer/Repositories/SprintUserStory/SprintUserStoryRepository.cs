using System.Collections.Generic;
using System.Data;
using System.Linq;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.SprintUserStory
{
    public partial class SprintUserStoryRepository : ISprintUserStoryRepository
    {
        private readonly IDomainFactory<Domain.SprintUserStory> _sprintUserStoryFactory = new SprintUserStoryFactory();
        private readonly RequestHelper<Domain.SprintUserStory> _requestHelper = new RequestHelper<Domain.SprintUserStory>();

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

        public List<Domain.SprintUserStory> GetByIdSprint(int idSprint)
        {
            return _requestHelper.GetByIdHelper(idSprint, ColIdSprint, ReqGetByIdSprint, _sprintUserStoryFactory);
        }

        public List<Domain.SprintUserStory> GetByIdUserStory(int idUserStory)
        {
            return _requestHelper.GetByIdHelper(idUserStory, ColIdUserStory, ReqGetByIdUserStory, _sprintUserStoryFactory);
        }

        // Post requests
        public Domain.SprintUserStory Create(Domain.SprintUserStory sprintUserStory)
        {
            if (Exists(sprintUserStory)) return null;
            
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
        
        // Utils for post request
        private bool Exists(Domain.SprintUserStory sprintUserStory)
        {
            var sprintUserStories = GetAll();
            return Enumerable.Contains(sprintUserStories, sprintUserStory);
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