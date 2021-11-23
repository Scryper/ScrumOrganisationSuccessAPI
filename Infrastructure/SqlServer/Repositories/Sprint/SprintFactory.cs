using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.Sprint
{
    public class SprintFactory : IDomainFactory<Domain.Sprint>
    {
        public Domain.Sprint CreateFromSqlReader(SqlDataReader reader)
        {
            return new Domain.Sprint
            {
                Id = reader.GetInt32(reader.GetOrdinal(SprintRepository.ColId)),
                SprintNumber = reader.GetInt32(reader.GetOrdinal(SprintRepository.ColSprintNumber)),
                IdProject = reader.GetInt32(reader.GetOrdinal(SprintRepository.ColIdProject)),
                Deadline = reader.GetDateTime(reader.GetOrdinal(SprintRepository.ColDeadline)),
                Description = reader.GetString(reader.GetOrdinal(SprintRepository.ColDescription)),
                Progression = reader.GetInt32(reader.GetOrdinal(SprintRepository.ColProgression))
            };
        }
    }
}