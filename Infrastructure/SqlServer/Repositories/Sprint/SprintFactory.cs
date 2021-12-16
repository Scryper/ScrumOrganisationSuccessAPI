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
                IdProject = reader.GetInt32(reader.GetOrdinal(SprintRepository.ColIdProject)),
                SprintNumber = reader.GetInt32(reader.GetOrdinal(SprintRepository.ColSprintNumber)),
                StartDate = reader.GetDateTime(reader.GetOrdinal(SprintRepository.ColStartDate)),
                Deadline = reader.GetDateTime(reader.GetOrdinal(SprintRepository.ColDeadline)),
                Description = reader.GetString(reader.GetOrdinal(SprintRepository.ColDescription))
            };
        }
    }
}