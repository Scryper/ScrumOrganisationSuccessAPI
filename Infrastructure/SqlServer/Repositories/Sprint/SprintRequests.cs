namespace Infrastructure.SqlServer.Repositories.Sprint
{
    public partial class SprintRepository
    {
        public const string TableName = "sprint";
        
        public const string ColId = "id";
        public const string ColSprintNumber = "sprint_number";
        public const string ColIdProject = "id_project";
        public const string ColDeadline = "deadline";
        public const string ColDescription = "description";
        public const string ColStartDate = "start_date";
        
        // Get requests
        private static readonly string ReqGetAll = $"select * from {TableName}"; 
        
        private static readonly string ReqGetById = $@"select * from {TableName} 
                                                    where {ColId} = @{ColId}"; 
        
        private static readonly string ReqGetByIdProject = $@"select * from {TableName} 
                                                           where {ColIdProject} = @{ColIdProject} 
                                                           order by {ColDeadline} asc"; 
        
        // Post requests
        private static readonly string ReqCreate = 
                        $@"insert into {TableName}({ColIdProject}, {ColSprintNumber}, {ColDeadline},  
                        {ColDescription}, {ColStartDate}) 
                        output inserted.{ColId} 
                        values(@{ColIdProject}, @{ColSprintNumber}, @{ColDeadline}, 
                        @{ColDescription}, @{ColStartDate})";
    }
}