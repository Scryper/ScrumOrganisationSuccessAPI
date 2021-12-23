namespace Infrastructure.SqlServer.Repositories.Project
{
    public partial class ProjectRepository
    {
        public const string TableName = "project";
        public const string TableUserProject = "user_project";

        public const string ColId = "id";
        public const string ColName = "name";
        public const string ColDeadline = "deadline";
        public const string ColDescription = "description";
        public const string ColRepositoryUrl = "repository_url";
        public const string ColStatus = "sos_status";
        public const string ColIdUser = "id_user";

        // Get requests
        private static readonly string ReqGetAll = $"select * from {TableName}"; 
        
        private static readonly string ReqGetById = $@"select * from {TableName} 
                                                    where {ColId} = @{ColId}";
        
        private static readonly string ReqGetByName = $@"select * from {TableName}
                                                      where {ColName} = @{ColName}";
        
        private static readonly string ReqGetActiveProject = $@"select * from {TableName} 
                                                                where  {ColStatus} != 3";

        private static readonly string ReqGetActiveProjectByUser = $@"select {TableName}.* from {TableName} 
                                                                inner join {TableUserProject} on 
                                                                {TableName}.{ColId} = {TableUserProject}.id_project 
                                                                where  {TableName}.{ColStatus} != 3 and 
                                                                {TableUserProject}.{ColIdUser} = @{ColIdUser} 
                                                                and {TableUserProject}.is_appliance = 0";

        private static readonly string ReqGetProjectNotFinishedIsLinked = $@"select {TableName}.* from {TableName} 
                                                                inner join {TableUserProject} on 
                                                                {TableName}.{ColId} = {TableUserProject}.id_project 
                                                                where  {TableName}.{ColStatus} != 3 and 
                                                                {TableUserProject}.{ColIdUser} = @{ColIdUser}";

        // Post requests
        private static readonly string ReqCreate = 
                    $@"insert into {TableName}({ColName}, {ColDeadline}, {ColDescription}, 
                    {ColRepositoryUrl})
                    output inserted.{ColId} 
                    values(@{ColName}, @{ColDeadline}, @{ColDescription}, 
                    @{ColRepositoryUrl})";
        
        // Put requests
        private static readonly string ReqUpdateState = $@"update {TableName} 
                                                                set {ColStatus} = @{ColStatus} 
                                                                where {ColId} = @{ColId}";
    }
}