using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.Meeting
{
    public class MeetingFactory : IDomainFactory<Domain.Meeting>
    {
        public Domain.Meeting CreateFromSqlReader(SqlDataReader reader)
        {
            return new Domain.Meeting
            {
                Id = reader.GetInt32(reader.GetOrdinal(MeetingRepository.ColId)),
                IdSprint = reader.GetInt32(reader.GetOrdinal(MeetingRepository.ColIdSprint)),
                Schedule = reader.GetDateTime(reader.GetOrdinal(MeetingRepository.ColSchedule)),
                Description = reader.GetString(reader.GetOrdinal(MeetingRepository.ColDescription)),
                MeetingUrl = reader.GetString(reader.GetOrdinal(MeetingRepository.ColUrl))
            };
        }
    }
}