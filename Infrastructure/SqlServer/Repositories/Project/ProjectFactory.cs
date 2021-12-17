using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.Project
{
    public class ProjectFactory : IDomainFactory<Domain.Project>
    {
        public Domain.Project CreateFromSqlReader(SqlDataReader reader)
        {
            return new Domain.Project
            {
                Id = reader.GetInt32(reader.GetOrdinal(ProjectRepository.ColId)),
                Name = reader.GetString(reader.GetOrdinal(ProjectRepository.ColName)),
                Deadline = reader.GetDateTime(reader.GetOrdinal(ProjectRepository.ColDeadline)),
                Description = reader.GetString(reader.GetOrdinal(ProjectRepository.ColDescription)),
                RepositoryUrl = reader.GetString(reader.GetOrdinal(ProjectRepository.ColRepositoryUrl)),
                Status = reader.GetInt16(reader.GetOrdinal(ProjectRepository.ColStatus))
            };
        }
    }
}