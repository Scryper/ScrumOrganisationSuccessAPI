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
        public const string ColUrl = "url";

        public const string ParticipationColIdMeeting = "participation.id_meeting";
        public const string ParticipationColIdUser = "participation.id_user";
        public const string UserColId = "sos_user.id";

        // Get requests
        private static readonly string ReqGetAll = $"select * from {TableName}";
        
        private static readonly string ReqGetById = $@"select * from {TableName} 
                                                    where {ColId} = @{ColId}"; 
        
        private static readonly string ReqGetByIdSprint = $@"select * from {TableName} 
                                                          where {ColIdSprint} = @{ColIdSprint} 
                                                          order by convert(date, {ColSchedule})"; 
        
        private static readonly string ReqGetByIdUser = 
                                $@"select * from {TableName} 
                                left join {ParticipationTableName} on {ColId} = {ParticipationColIdMeeting} 
                                left join {UserTableName} on {ParticipationColIdUser} = {UserColId} 
                                where {UserColId} = @{ColId}";
        
        // Post requests
        private static readonly string ReqCreate = 
                                $@"insert into {TableName}({ColIdSprint}, {ColSchedule}, {ColDescription}) 
                                output inserted.{ColId} 
                                values(@{ColIdSprint}, @{ColSchedule}, @{ColDescription})";
        
        // Put requests
        private static readonly string ReqUpdateSchedule = $@"update {TableName} 
                                                           set {ColSchedule} = @{ColSchedule} 
                                                           where {ColId} = @{ColId}";
        
        // Delete Requests
        private static readonly string ReqDeleteById = $@"delete from {TableName} 
                                                       where {ColId} = @{ColId}";
    }
}