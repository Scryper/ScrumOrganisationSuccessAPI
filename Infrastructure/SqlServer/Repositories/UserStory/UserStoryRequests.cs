namespace Infrastructure.SqlServer.Repositories.UserStory
{
    public partial class UserStoryRepository
    {
        public const string TableName = "user_story";
        public const string SprintUserStoryTableName = "sprint_user_story";
        public const string SprintTableName = "sprint";
        
        public const string ColId = "id";
        public const string ColName = "name";
        public const string ColDescription = "description";
        public const string ColIsDone = "is_done";
        public const string ColIdProject = "id_project";
        
        public const string UserStoryColIdProject = "user_story.id_project";
        public const string SprintUserColIdUserStory = "sprint_user_story.id_user_story";
        public const string SprintUserColIdSprint = "sprint_user_story.id_sprint";
        public const string SprintColId = "sprint.id";
        
        // Get requests
        private static readonly string ReqGetAll = $"select * from {TableName}";

        private static readonly string ReqGetById = $@"select * from {TableName} 
                                                    where {ColId} = @{ColId}"; 
        
        private static readonly string ReqGetByIdProject = 
                                    $@"select * from {TableName} 
                                    left join {SprintUserStoryTableName} on {ColId} = {SprintUserColIdUserStory} 
                                    left join {SprintTableName} on {SprintUserColIdSprint} = {SprintColId} 
                                    where {UserStoryColIdProject} = @{ColId}";
                                
        private static readonly string ReqGetByIdSprint = 
                                    $@"select * from {TableName} 
                                    left join {SprintUserStoryTableName} on {ColId} = {SprintUserColIdUserStory} 
                                    left join {SprintTableName} on {SprintUserColIdSprint} = {SprintColId} 
                                    where {SprintColId} = @{ColId}"; 
        
        // Post requests
        private static readonly string ReqCreate = 
                                $@"insert into {TableName}({ColName}, {ColDescription}, {ColIsDone}, {ColIdProject})  
                                output inserted.{ColId} 
                                values(@{ColName}, @{ColDescription}, @{ColIsDone}, @{ColIdProject})";
        
        // Put requests
        private static readonly string ReqUpdateIsDone = $@"update {TableName} 
                                                         set {ColIsDone} = @{ColIsDone} 
                                                         where {ColId} = @{ColId}";
        
        // Delete requests
        private static readonly string ReqDeleteById = $@"delete from {TableName} 
                                                       where {ColId} = @{ColId}";
    }
}