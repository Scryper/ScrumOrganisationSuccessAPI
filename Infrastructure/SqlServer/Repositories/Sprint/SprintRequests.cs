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
        public const string ColProgression = "progression";
        
        // Get requests
        private static readonly string ReqGetAll = $"select * from {TableName}"; 
        
        private static readonly string ReqGetById = $@"select * from {TableName} 
                                                    where {ColId} = @{ColId}"; 
        
        private static readonly string ReqGetByIdProject = $@"select * from {TableName} 
                                                           where {ColIdProject} = @{ColIdProject} 
                                                           order by {ColDeadline} asc"; 
        
        // Post requests
        private static readonly string ReqCreate = 
                        $@"insert into {TableName}({ColSprintNumber}, {ColIdProject}, {ColDeadline},  
                        {ColDescription}, {ColProgression}) 
                        output inserted.{ColId} 
                        values(@{ColSprintNumber}, @{ColIdProject}, @{ColDeadline}, 
                        @{ColDescription}, @{ColProgression})";

        // Put requests
        private static readonly string ReqUpdateProgression = $@"update {TableName} 
                                                              set {ColProgression} = @{ColProgression} 
                                                              where {ColId} = @{ColId}";
        
        // Delete Requests
        private static readonly string ReqDeleteById = $@"delete from {TableName} 
                                                       where {ColId} = @{ColId}";
    }
}