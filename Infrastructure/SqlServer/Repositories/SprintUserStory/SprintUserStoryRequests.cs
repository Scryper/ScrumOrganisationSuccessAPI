namespace Infrastructure.SqlServer.Repositories.SprintUserStory
{
    public partial class SprintUserStoryRepository
    {
        public const string TableName = "sprint_user_story";
        public const string ColIdSprint = "id_sprint";
        public const string ColIdUserStory = "id_user_story";
        
        // Get requests
        private static readonly string ReqGetAll = $"select * from {TableName}";

        private static readonly string ReqGetByIdSprint = $@"select * from {TableName} 
                                                            where {ColIdSprint} = @{ColIdSprint}";

        // Post requests
        private static readonly string ReqCreate = $@"insert into {TableName}({ColIdSprint}, {ColIdUserStory}) 
                                                    values(@{ColIdSprint}, @{ColIdUserStory})";
    }
}