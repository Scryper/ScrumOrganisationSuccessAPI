using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;
using NotImplementedException = System.NotImplementedException;

namespace Infrastructure.SqlServer.Repositories.UserTechnology
{
    public class UserTechnologyFactory : IDomainFactory<Domain.UserTechnology>
    {
        public Domain.UserTechnology CreateFromSqlReader(SqlDataReader reader)
        {
            return new Domain.UserTechnology
            {
                IdTechnology = reader.GetInt32(reader.GetOrdinal(UserTechnologyRepository.ColIdTechnology)),
                IdUser = reader.GetInt32(reader.GetOrdinal(UserTechnologyRepository.ColIdUser))
            };
        }
    }
}