﻿namespace Infrastructure.SqlServer.Repositories.User
{
    public partial class UserRepository
    {
        public const string TableName = "sos_user";
        public const string UserProjectTableName = "user_project";
        public const string ProjectTableName = "project";
        public const string ParticipationTableName = "participation";
        public const string MeetingTableName = "meeting";
        
        public const string ColId = "id";
        public const string ColFirstName = "firstname";
        public const string ColLastName = "lastname";
        public const string ColPassword = "password";
        public const string ColEmail = "email";
        public const string ColRole = "role";
        public const string ColBirthdate = "birthdate";
        public const string ColProfilePicture = "profile_picture";
        
        public const string ProjectUserColIdUser = "user_project.id_user";
        public const string ProjectUserColIdProject = "user_project.id_project";
        public const string ProjectColId = "project.id";
        public const string ParticipationColIdUser = "participation.id_user";
        public const string ParticipationColIdMeeting = "participation.id_meeting";
        public const string MeetingColId = "meeting.id";
        
        // Get requests
        private static readonly string ReqGetAll = $"select * from {TableName}";

        private static readonly string ReqByEmail = $@"select * from {TableName} 
                                                    where {ColEmail} = @{ColEmail}";
            
        private static readonly string ReqGetById = $@"select * from {TableName} 
                                                    where {ColId} = @{ColId}";

        private static readonly string ReqGetByIdProject = 
                                        $@"select * from {TableName} 
                                        left join {UserProjectTableName} on {ColId} = {ProjectUserColIdUser} 
                                        left join {ProjectTableName} on {ProjectUserColIdProject} = {ProjectColId} 
                                        where {ProjectColId} = @{ColId}";
        
        private static readonly string ReqGetByIdProjectIsWorking = 
                                        $@"select * from {TableName} 
                                        left join {UserProjectTableName} on {ColId} = {ProjectUserColIdUser} 
                                        left join {ProjectTableName} on {ProjectUserColIdProject} = {ProjectColId} 
                                        where {ProjectColId} = @{ColId} and where {UserProjectTableName}.is_appliance = 0";
        
        private static readonly string ReqGetByIdMeeting = 
                                    $@"select * from {TableName} 
                                    left join {ParticipationTableName} on {ColId} = {ParticipationColIdUser} 
                                    left join {MeetingTableName} on {ParticipationColIdMeeting} = {MeetingColId} 
                                    where {MeetingColId} = @{ColId}";

        // Post requests
        private static readonly string ReqCreate = 
                                    $@"insert into {TableName}({ColFirstName}, {ColLastName}, {ColPassword}, {ColEmail}, {ColRole}, {ColBirthdate}) 
                                    output inserted.{ColId} 
                                    values(@{ColFirstName}, @{ColLastName}, @{ColPassword}, @{ColEmail}, @{ColRole}, @{ColBirthdate})";
        
        // Put requests
        private static readonly string ReqUpdateRole = $@"update {TableName} 
                                                       set {ColRole} = @{ColRole} 
                                                       where {ColId} = @{ColId}";
        
        private static readonly string ReqUpdatePassword = $@"update {TableName} 
                                                           set {ColPassword} = @{ColPassword} 
                                                           where {ColId} = @{ColId}";
        
        private static readonly string ReqUpdateEmail = $@"update {TableName} 
                                                        set {ColEmail} = @{ColEmail} 
                                                        where {ColId} = @{ColId}";
        
        private static readonly string ReqUpdateFirstNameLastName = $@"update {TableName} 
                                                        set {ColFirstName} = @{ColFirstName}, 
                                                        {ColLastName} = @{ColLastName} 
                                                        where {ColId} = @{ColId}";
        
        // Delete Requests
        private static readonly string ReqDeleteById = $@"delete from {TableName} 
                                                       where {ColId} = @{ColId}";
    }
}