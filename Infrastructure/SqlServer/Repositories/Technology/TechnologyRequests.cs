namespace Infrastructure.SqlServer.Repositories.Technology
{
    public partial class  TechnologyRepository
    {
        public const string TableName = "technology";
        public const string ColId = "id";
        public const string ColName = "name";
        
        // Get Requests
        private static readonly string ReqGetAll = $"select *  from {TableName}";

        private static readonly string ReqGetByName = $@"select * from {TableName} 
                                                       where {ColName} =@{ColName}";
    }
}