using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.SprintUserStory
{
    public class SprintUserStoryFactory : IDomainFactory<Domain.SprintUserStory>
    {
        public Domain.SprintUserStory CreateFromSqlReader(SqlDataReader reader)
        {
            return new Domain.SprintUserStory
            {
                IdSprint = reader.GetInt32(reader.GetOrdinal(SprintUserStoryRepository.ColIdSprint)),
                IdUserStory = reader.GetInt32(reader.GetOrdinal(SprintUserStoryRepository.ColIdUserStory))
            };
        }
    }
}