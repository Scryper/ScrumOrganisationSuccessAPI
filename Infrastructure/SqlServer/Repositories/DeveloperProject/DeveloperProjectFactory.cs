using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.DeveloperProject
{
    public class DeveloperProjectFactory : IDomainFactory<Domain.DeveloperProject>
    {
        public Domain.DeveloperProject CreateFromSqlReader(SqlDataReader reader)
        {
            return new Domain.DeveloperProject()
            {
                IdDeveloper = reader.GetInt32(reader.GetOrdinal(DeveloperProjectRepository.ColIdDeveloper)),
                IdProject = reader.GetInt32(reader.GetOrdinal(DeveloperProjectRepository.ColIdProject)),
                IsAppliance = reader.GetBoolean(reader.GetOrdinal(DeveloperProjectRepository.ColIsAppliance))
            };
        }
    }
}