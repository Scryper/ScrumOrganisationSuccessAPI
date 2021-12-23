namespace Infrastructure.SqlServer.Repositories.UserStory
{
    public partial class UserStoryRepository
    {
        public const string TableName = "user_story";
        public const string TableNameSprintUserStory = "sprint_user_story";
        
        public const string ColId = "id";
        public const string ColName = "name";
        public const string ColDescription = "description";
        public const string ColPriority = "priority";
        public const string ColIdProject = "id_project";
        public const string ColIdSprint = "id_sprint";
        
        // Get requests
        private static readonly string ReqGetAll = $@"select * from {TableName} 
                                                    order by {ColPriority} asc";

        private static readonly string ReqGetById = $@"select * from {TableName} 
                                                    where {ColId} = @{ColId}";
        
        private static readonly string ReqGetByIdProject = 
                                    $@"select * from {TableName} 
                                    where {ColIdProject} = @{ColIdProject} 
                                    order by {ColPriority} asc";

        private static readonly string ReqGetByIdSprint =
            $@"select {TableName}.* from {TableName} inner join {TableNameSprintUserStory} 
                                                            on {TableName}.{ColId} = {TableNameSprintUserStory}.id_user_story 
                                                            where {TableNameSprintUserStory}.{ColIdSprint} = @{ColIdSprint}";
        
        // Post requests
        private static readonly string ReqCreate = 
                                $@"insert into {TableName}({ColIdProject}, {ColName}, {ColDescription}, {ColPriority})  
                                output inserted.{ColId} 
                                values(@{ColIdProject}, @{ColName}, @{ColDescription}, @{ColPriority})";
        
        // Put requests
        private static readonly string ReqUpdateUserStory = $@"update {TableName} 
                                                        set {ColName} = @{ColName}, 
                                                        {ColDescription} = @{ColDescription}, 
                                                        {ColPriority} = @{ColPriority} 
                                                        where {ColId} = @{ColId}";
        
        // Delete requests
        private static readonly string ReqDeleteById = $@"delete from {TableName} 
                                                       where {ColId} = @{ColId}";
    }
}