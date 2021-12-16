namespace Infrastructure.SqlServer.Repositories.Participation
{
    public partial class ParticipationRepository
    {
        public const string TableName = "participation";

        public const string ColIdUser = "id_user";

        public const string ColIdMeeting = "id_meeting";
        
        private static readonly string ReqGetAll = $"select * from {TableName}";

        private static readonly string ReqGetByUserId = $@"select * from {TableName} 
                                                        where {ColIdUser} = @{ColIdUser}";

        private static readonly string ReqGetByMeetingId = $@"select * from {TableName} 
                                                            where {ColIdMeeting} = @{ColIdMeeting}";

        private static readonly string ReqCreate = $@"insert into {TableName}({ColIdUser},{ColIdMeeting}) 
                                                    values(@{ColIdUser},@{ColIdMeeting})";

        private static readonly string ReqDelete = $@"delete from {TableName} 
                                                        where {ColIdMeeting} = @{ColIdMeeting} and 
                                                        {ColIdUser} = @{ColIdUser}";
    }
}