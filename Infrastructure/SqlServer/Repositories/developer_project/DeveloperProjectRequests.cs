namespace Infrastructure.SqlServer.Repositories.developer_project
{
    public partial class DeveloperProjectRepository
    {
        public const string TableName = "developer_project";
        public const string ColIdDeveloper = "id_developer";
        public const string ColIdProject = "id_project";
        public const string ColIsAppliance = "is_appliance";
        
        // Get requests
        private static readonly string ReqGetAll = $"select * from {TableName}";
        
        private static readonly string ReqGetByDeveloperId = $@"select * from {TableName} 
                                                              where {ColIdDeveloper} = @{ColIdDeveloper}";

        private static readonly string ReqGetByProjectId = $@"select * from {TableName} 
                                                            where {ColIdProject} = @{ColIdProject}";

        // Post requests
        private static readonly string ReqCreate = $@"insert into {TableName}({ColIdDeveloper},{ColIdProject},{ColIsAppliance}) 
                                                    values(@{ColIdDeveloper}, @{ColIdProject}, @{ColIsAppliance})";

        // Put requests
        private static readonly string ReqUpdate = $@"update {TableName} 
                                                    set {ColIsAppliance} = @{ColIsAppliance} 
                                                    where {ColIdDeveloper} = @{ColIdDeveloper} and 
                                                    {ColIdProject} = @{ColIdProject}";
        
        // Delete requests
        private static readonly string ReqDelete = $@"delete from {TableName} 
                                                    where {ColIdDeveloper} = @{ColIdDeveloper} and 
                                                    {ColIdProject} = @{ColIdProject}";
    }
}