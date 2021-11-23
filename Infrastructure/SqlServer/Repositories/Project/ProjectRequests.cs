namespace Infrastructure.SqlServer.Repositories.Project
{
    public partial class ProjectRepository
    {
        public const string TableName = "project";
        public const string UserTableName = "user";
        
        public const string ColId = "id";
        public const string ColName = "name";
        public const string ColDeadline = "deadline";
        public const string ColDescription = "description";
        public const string ColRepositoryUrl = "repository_url";
        public const string ColIdProductOwner = "id_product_owner";
        public const string ColIdScrumMaster = "id_scrum_master";
        
        public const string UserColId = "user.id";

        // Get requests
        private static readonly string ReqGetAll = $"select * from {TableName}"; 
        
        private static readonly string ReqGetById = $"select * from {TableName} " + 
                                                    $"where {ColId} = @{ColId}";
        
        private static readonly string ReqGetByIdProductOwner = 
                                                    $"select * from {TableName} " +
                                                    $"left join {UserTableName} on {UserColId} = {ColIdProductOwner} " +
                                                    $"where {UserColId} = @{ColIdProductOwner}";
        
        private static readonly string ReqGetByIdScrumMaster = 
                                                    $"select * from {TableName} " +
                                                    $"left join {UserTableName} on {UserColId} = {ColIdScrumMaster} "+
                                                    $"where {UserColId} = @{ColIdScrumMaster}";
        
        // Post requests
        private static readonly string ReqCreate = 
                    $"insert into {TableName}({ColName}, {ColDeadline}, {ColDescription}, " + 
                    $"{ColRepositoryUrl}, {ColIdProductOwner}, {ColIdScrumMaster}) " + // Second part of insert
                    $"output inserted.{ColId} " +
                    $"values(@{ColName}, @{ColDeadline}, @{ColDescription}, " +
                    $"@{ColRepositoryUrl}, @{ColIdProductOwner}, @{ColIdScrumMaster})"; // Second part of values
        
        // Put requests
        private static readonly string ReqUpdateRepositoryUrl = $"update {TableName} " +
                                                                $"set {ColRepositoryUrl} = @{ColRepositoryUrl} " +
                                                                $"where {ColId} = @{ColId}";
        
        // Delete Requests
        private static readonly string ReqDeleteById = $"delete from {TableName} " +
                                                       $"where {ColId} = @{ColId}";
    }
}