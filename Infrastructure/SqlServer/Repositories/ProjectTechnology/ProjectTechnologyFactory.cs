using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;
using NotImplementedException = System.NotImplementedException;

namespace Infrastructure.SqlServer.Repositories.ProjectTechnology
{
    public class ProjectTechnologyFactory : IDomainFactory<Domain.ProjectTechnology>
    {
        public Domain.ProjectTechnology CreateFromSqlReader(SqlDataReader reader)
        {
            return new Domain.ProjectTechnology{
                IdTechnology = reader.GetInt32(reader.GetOrdinal(ProjectTechnologyRepository.ColIdTechnology)),
                IdProject = reader.GetInt32(reader.GetOrdinal(ProjectTechnologyRepository.ColIdProject))
            };
        }
    }
}