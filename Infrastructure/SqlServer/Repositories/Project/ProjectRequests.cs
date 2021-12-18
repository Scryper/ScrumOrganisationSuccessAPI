namespace Infrastructure.SqlServer.Repositories.Project
{
    public partial class ProjectRepository
    {
        public const string TableName = "project";

        public const string ColId = "id";
        public const string ColName = "name";
        public const string ColDeadline = "deadline";
        public const string ColDescription = "description";
        public const string ColRepositoryUrl = "repository_url";
        public const string ColStatus = "sos_status";

        // Get requests
        private static readonly string ReqGetAll = $"select * from {TableName}"; 
        
        private static readonly string ReqGetById = $@"select * from {TableName} 
                                                    where {ColId} = @{ColId}";
        
        private static readonly string ReqGetByName = $@"select * from {TableName}
                                                      where {ColName} = @{ColName}";
        
        // Post requests
        private static readonly string ReqCreate = 
                    $@"insert into {TableName}({ColName}, {ColDeadline}, {ColDescription}, 
                    {ColRepositoryUrl})
                    output inserted.{ColId} 
                    values(@{ColName}, @{ColDeadline}, @{ColDescription}, 
                    @{ColRepositoryUrl})";
        
        // Put requests
        private static readonly string ReqUpdateRepositoryUrl = $@"update {TableName} 
                                                                set {ColRepositoryUrl} = @{ColRepositoryUrl} 
                                                                where {ColId} = @{ColId}";
        
        private static readonly string ReqUpdateState = $@"update {TableName} 
                                                                set {ColStatus} = @{ColStatus} 
                                                                where {ColId} = @{ColId}";
        
        
        // Delete Requests
        private static readonly string ReqDeleteById = $@"delete from {TableName} 
                                                       where {ColId} = @{ColId}";
    }
}