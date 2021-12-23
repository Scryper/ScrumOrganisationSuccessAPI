namespace Infrastructure.SqlServer.Repositories.Meeting
{
    public partial class MeetingRepository
    {
        public const string TableName = "meeting";
        public const string ParticipationTableName = "participation";
        public const string UserTableName = "sos_user";
        
        public const string ColId = "id";
        public const string ColIdSprint = "id_sprint";
        public const string ColSchedule = "schedule";
        public const string ColDescription = "description";
        public const string ColUrl = "meeting_url";

        public const string ParticipationColIdMeeting = "participation.id_meeting";
        public const string ParticipationColIdUser = "participation.id_user";
        public const string UserColId = "sos_user.id";

        // Get requests
        private static readonly string ReqGetAll = $"select * from {TableName}";
        
        private static readonly string ReqGetByIdUser = 
                                $@"select * from {TableName} 
                                left join {ParticipationTableName} on {ColId} = {ParticipationColIdMeeting} 
                                left join {UserTableName} on {ParticipationColIdUser} = {UserColId} 
                                where {UserColId} = @{ColId} 
                                order by convert(date, {ColSchedule})";
        
        // Post requests
        private static readonly string ReqCreate = 
                                $@"insert into {TableName}({ColIdSprint}, {ColSchedule}, {ColDescription}, {ColUrl}) 
                                output inserted.{ColId} 
                                values(@{ColIdSprint}, @{ColSchedule}, @{ColDescription}, @{ColUrl})";
    }
}