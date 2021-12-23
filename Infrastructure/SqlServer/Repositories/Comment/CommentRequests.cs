namespace Infrastructure.SqlServer.Repositories.Comment
{
    public partial class CommentRepository
    {
        public const string TableName = "comment";
        public const string ColId = "id";
        public const string ColIdUserStory = "id_user_story";
        public const string ColIdUser = "id_user";
        public const string ColPostedAt = "posted_at";
        public const string ColContent = "content";
        
        // Get requests
        private static readonly string ReqGetByIdUserStory = $@"select * from {TableName} 
                                                             where {ColIdUserStory} = @{ColIdUserStory} 
                                                             order by convert(datetime, {ColPostedAt},103) asc";

        // Post requests
        private static readonly string ReqCreate = 
                            $@"insert into {TableName}({ColIdUserStory}, {ColIdUser}, {ColPostedAt}, {ColContent}) 
                            output inserted.{ColId} 
                            values(@{ColIdUserStory}, @{ColIdUser}, convert(datetime, @{ColPostedAt}, 131), @{ColContent})";
        
        // Put requests
        private static readonly string ReqUpdateContent = $@"update {TableName} 
                                                          set {ColContent} = @{ColContent} 
                                                          where {ColId} = @{ColId}";
        
        // Delete Requests
        private static readonly string ReqDeleteById = $@"delete from {TableName} 
                                                       where {ColId} = @{ColId}";
    }
}