using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.UserStory
{
    public class UserStoryFactory : IDomainFactory<Domain.UserStory>
    {
        public Domain.UserStory CreateFromSqlReader(SqlDataReader reader)
        {
            return new Domain.UserStory
            {
                Id = reader.GetInt32(reader.GetOrdinal(UserStoryRepository.ColId)),
                IdProject = reader.GetInt32(reader.GetOrdinal(UserStoryRepository.ColIdProject)),
                Name = reader.GetString(reader.GetOrdinal(UserStoryRepository.ColName)),
                Description = reader.GetString(reader.GetOrdinal(UserStoryRepository.ColDescription)),
                Priority = reader.GetInt16(reader.GetOrdinal(UserStoryRepository.ColPriority))
            };
        }
    }
}