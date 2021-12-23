namespace Infrastructure.SqlServer.Repositories.Participation
{
    public partial class ParticipationRepository
    {
        public const string TableName = "participation";

        public const string ColIdUser = "id_user";

        public const string ColIdMeeting = "id_meeting";
        
        private static readonly string ReqGetAll = $"select * from {TableName}";

        private static readonly string ReqGetByIdUser = $@"select * from {TableName} 
                                                        where {ColIdUser} = @{ColIdUser}";

        private static readonly string ReqGetByIdMeeting = $@"select * from {TableName} 
                                                            where {ColIdMeeting} = @{ColIdMeeting}";

        private static readonly string ReqCreate = $@"insert into {TableName}({ColIdUser},{ColIdMeeting}) 
                                                    values(@{ColIdUser},@{ColIdMeeting})";
    }
}