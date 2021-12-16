using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;
using NotImplementedException = System.NotImplementedException;

namespace Infrastructure.SqlServer.Repositories.Technology
{
    public class TechnologyFactory : IDomainFactory<Domain.Technology>
    {
        public Domain.Technology CreateFromSqlReader(SqlDataReader reader)
        {
            return new Domain.Technology
            {
                Id = reader.GetInt32(reader.GetOrdinal(TechnologyRepository.ColId)),
                Name = reader.GetString(reader.GetOrdinal(TechnologyRepository.ColName)),
            };
        }
    }
}