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
                Firstname = reader.GetString(reader.GetOrdinal(UserRepository.ColFirstName)),
                Lastname = reader.GetString(reader.GetOrdinal(UserRepository.ColLastName)),
                Email = reader.GetString(reader.GetOrdinal(UserRepository.ColEmail)),
                Password = reader.GetString(reader.GetOrdinal(UserRepository.ColPassword)),
                Role = reader.GetInt16(reader.GetOrdinal(UserRepository.ColRole)),
                Birthdate = reader.GetDateTime(reader.GetOrdinal(UserRepository.ColBirthdate)),
                ProfilePicture = reader.GetString(reader.GetOrdinal(UserRepository.ColProfilePicture))
            };
        }
    }
}