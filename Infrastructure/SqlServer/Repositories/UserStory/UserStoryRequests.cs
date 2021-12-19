namespace Infrastructure.SqlServer.Repositories.UserStory
{
    public partial class UserStoryRepository
    {
        public const string TableName = "user_story";
        
        public const string ColId = "id";
        public const string ColName = "name";
        public const string ColDescription = "description";
        public const string ColPriority = "priority";
        public const string ColIdProject = "id_project";
        
        // Get requests
        private static readonly string ReqGetAll = $@"select * from {TableName} 
                                                    order by {ColPriority} asc";

        private static readonly string ReqGetById = $@"select * from {TableName} 
                                                    where {ColId} = @{ColId}";
        
        private static readonly string ReqGetByIdProject = 
                                    $@"select * from {TableName} 
                                    where {ColIdProject} = @{ColIdProject} 
                                    order by {ColPriority} asc";
        
        // Post requests
        private static readonly string ReqCreate = 
                                $@"insert into {TableName}({ColIdProject}, {ColName}, {ColDescription}, {ColPriority})  
                                output inserted.{ColId} 
                                values(@{ColIdProject}, @{ColName}, @{ColDescription}, @{ColPriority})";
        
        // Put requests
        private static readonly string ReqUpdateUS = $@"update {TableName} 
                                                        set {ColName} = @{ColName}, 
                                                        {ColDescription} = @{ColDescription}, 
                                                        {ColPriority} = @{ColPriority} 
                                                        where {ColId} = @{ColId}";
        
        // Delete requests
        private static readonly string ReqDeleteById = $@"delete from {TableName} 
                                                       where {ColId} = @{ColId}";
    }
}