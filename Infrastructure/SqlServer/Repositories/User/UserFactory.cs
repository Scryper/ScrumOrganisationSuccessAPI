using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.User
{
    public class UserFactory : IDomainFactory<Domain.User>
    {
        public Domain.User CreateFromSqlReader(SqlDataReader reader)
        {
            return new Domain.User
            {
                Id = reader.GetInt32(reader.GetOrdinal(UserRepository.ColId)),
                Pseudo = reader.GetString(reader.GetOrdinal(UserRepository.ColPseudo)),
                Password = reader.GetString(reader.GetOrdinal(UserRepository.ColPassword)),
                Email = reader.GetString(reader.GetOrdinal(UserRepository.ColEmail)),
                Role = reader.GetInt16(reader.GetOrdinal(UserRepository.ColRole))
            };
        }
    }
}