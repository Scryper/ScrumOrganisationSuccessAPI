namespace Infrastructure.SqlServer.Repositories.Project
{
    public partial class ProjectRepository
    {
        public const string TableName = "project";
        public const string UserTableName = "sos_user";
        
        public const string ColId = "id";
        public const string ColName = "name";
        public const string ColDeadline = "deadline";
        public const string ColDescription = "description";
        public const string ColRepositoryUrl = "repository_url";
        public const string ColIdProductOwner = "id_product_owner";
        public const string ColStatus = "sos_status";
        
        public const string UserColId = "sos_user.id";

        // Get requests
        private static readonly string ReqGetAll = $"select * from {TableName}"; 
        
        private static readonly string ReqGetById = $@"select * from {TableName} 
                                                    where {ColId} = @{ColId}";
        
        private static readonly string ReqGetByName = $@"select * from {TableName}
                                                      where {ColName} = @{ColName}";
        
        private static readonly string ReqGetByIdProductOwner = 
                                                    $@"select * from {TableName} 
                                                    left join {UserTableName} on {UserColId} = {ColIdProductOwner} 
                                                    where {UserColId} = @{ColIdProductOwner}";

        // Post requests
        private static readonly string ReqCreate = 
                    $@"insert into {TableName}({ColIdProductOwner}, {ColName}, {ColDeadline}, {ColDescription}, 
                    {ColRepositoryUrl})
                    output inserted.{ColId} 
                    values(@{ColIdProductOwner}, @{ColName}, @{ColDeadline}, @{ColDescription}, 
                    @{ColRepositoryUrl})";
        
        // Put requests
        private static readonly string ReqUpdateRepositoryUrl = $@"update {TableName} 
                                                                set {ColRepositoryUrl} = @{ColRepositoryUrl} 
                                                                where {ColId} = @{ColId}";
        
        // Delete Requests
        private static readonly string ReqDeleteById = $@"delete from {TableName} 
                                                       where {ColId} = @{ColId}";
    }
}