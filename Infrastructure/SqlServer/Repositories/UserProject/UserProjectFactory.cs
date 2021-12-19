using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.DeveloperProject
{
    public class UserProjectFactory : IDomainFactory<Domain.UserProject>
    {
        public Domain.UserProject CreateFromSqlReader(SqlDataReader reader)
        {
            return new Domain.UserProject()
            {
                IdDeveloper = reader.GetInt32(reader.GetOrdinal(UserProject.UserProjectRepository.ColIdUser)),
                IdProject = reader.GetInt32(reader.GetOrdinal(UserProject.UserProjectRepository.ColIdProject)),
                IsAppliance = reader.GetBoolean(reader.GetOrdinal(UserProject.UserProjectRepository.ColIsAppliance))
            };
        }
    }
}