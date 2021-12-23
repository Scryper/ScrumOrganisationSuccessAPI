namespace Infrastructure.SqlServer.Repositories.UserTechnology
{
    public partial class UserTechnologyRepository
    {
        public const string TableName = "user_technology";

        public const string ColIdUser = "id_user";
        public const string ColIdTechnology = "id_technology";

        // Get Requests
        private static readonly string ReqGetAll = $"select * from {TableName}";

        private static readonly string ReqGetByUserId = $@"select * from {TableName} 
                                                        where {ColIdUser} = @{ColIdUser}";

        private static readonly string ReqGetByTechnology = $@"select * from {TableName} 
                                                            where {ColIdTechnology} = @{ColIdTechnology}";
        
        private static readonly string ReqGetByIdTechnologyIdUser = $@"select * from {TableName} 
                                                            where {ColIdTechnology} = @{ColIdTechnology} and {ColIdUser} = @{ColIdUser}";

        private static readonly string ReqCreate = $@"insert into {TableName}({ColIdUser},{ColIdTechnology}) 
                                                    values(@{ColIdUser},@{ColIdTechnology})";

        private static readonly string ReqDelete = $@"delete from {TableName} 
                                                        where {ColIdTechnology} = @{ColIdTechnology} and 
                                                        {ColIdUser} = @{ColIdUser}";
    }
}