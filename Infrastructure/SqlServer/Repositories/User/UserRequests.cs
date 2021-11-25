namespace Infrastructure.SqlServer.Repositories.User
{
    public partial class UserRepository
    {
        public const string TableName = "sos_user";
        public const string ProjectUserTableName = "project_user";
        public const string ProjectTableName = "project";
        public const string ParticipationTableName = "participation";
        public const string MeetingTableName = "meeting";
        
        public const string ColId = "id";
        public const string ColPseudo = "pseudo";
        public const string ColPassword = "password";
        public const string ColEmail = "email";
        public const string ColRole = "role";
        
        public const string ProjectUserColIdUser = "project_user.id_user";
        public const string ProjectUserColIdProject = "project_user.id_project";
        public const string ProjectColId = "project.id";
        public const string ParticipationColIdUser = "participation.id_user";
        public const string ParticipationColIdMeeting = "participation.id_meeting";
        public const string MeetingColId = "meeting.id";
        
        // Get requests
        private static readonly string ReqGetAll = $"select * from {TableName}";
        
        private static readonly string ReqGetById = $"select * from {TableName} " +
                                                    $"where {ColId} = @{ColId}";
        
        private static readonly string ReqByEmail = $"select * from {TableName} " +
                                                    $"where {ColEmail} = @{ColEmail}";

        private static readonly string ReqGetByIdProject = 
                                        $"select * from {TableName} " +
                                        $"left join {ProjectUserTableName} on {ColId} = {ProjectUserColIdUser} " +
                                        $"left join {ProjectTableName} on {ProjectUserColIdProject} = {ProjectColId} "+
                                        $"where {ProjectColId} = @{ProjectColId}";
        
        private static readonly string ReqGetByIdMeeting = 
                                    $"select * from {TableName} " +
                                    $"left join {ParticipationTableName} on {ColId} = {ParticipationColIdUser} " +
                                    $"left join {MeetingTableName} on {ParticipationColIdMeeting} = {MeetingColId} "+
                                    $"where {MeetingColId} = @{MeetingColId}";

        // Post requests
        private static readonly string ReqCreate = 
                                    $"insert into {TableName}({ColPseudo}, {ColPassword}, {ColEmail}, {ColRole}) " + 
                                    $"output inserted.{ColId} " +
                                    $"values(@{ColPseudo}, @{ColPassword}, @{ColEmail}, @{ColRole})";
        
        // Put requests
        private static readonly string ReqUpdateRole = $"update {TableName} " +
                                                       $"set {ColRole} = @{ColRole} " +
                                                       $"where {ColId} = @{ColId}";
        
        private static readonly string ReqUpdatePassword = $"update {TableName} " +
                                                           $"set {ColPassword} = @{ColPassword} " +
                                                           $"where {ColId} = @{ColId}";
        
        private static readonly string ReqUpdateEmail = $"update {TableName} " +
                                                        $"set {ColEmail} = @{ColEmail} " +
                                                        $"where {ColId} = @{ColId}";
        
        private static readonly string ReqUpdatePseudo = $"update {TableName} " +
                                                         $"set {ColPseudo} = @{ColPseudo} " +
                                                         $"where {ColId} = @{ColId}";
        
        // Delete Requests
        private static readonly string ReqDeleteById = $"delete from {TableName} " +
                                                       $"where {ColId} = @{ColId}";
    }
}