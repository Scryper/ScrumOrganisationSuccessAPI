using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;
using NotImplementedException = System.NotImplementedException;

namespace Infrastructure.SqlServer.Repositories.Participation
{
    public class ParticipationFactory : IDomainFactory<Domain.Participation>
    {
        public Domain.Participation CreateFromSqlReader(SqlDataReader reader)
        {
            return new Domain.Participation
            {
                IdMeeting = reader.GetInt32(reader.GetOrdinal(ParticipationRepository.ColIdMeeting)),
                IdUser = reader.GetInt32(reader.GetOrdinal(ParticipationRepository.ColIdUser))
            };
        }
    }
}