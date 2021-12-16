namespace Infrastructure.SqlServer.Repositories.ProjectTechnology
{
    public partial class ProjectTechnologyRepository
    {
        public const string TableName = "project_technology";

        public const string ColIdProject = "id_project";
        public const string ColIdTechnology = "id_technology";
        
        // Get Requests
        private static readonly string ReqGetAll = $"select * from {TableName}";

        private static readonly string ReqGetByIdProject = $@"select *  from {TableName} 
                                                            where {ColIdProject} = @{ColIdProject}";

        private static readonly string ReqGetByIdTechnology = $@"select * from {TableName} 
                                                                where {ColIdTechnology} = @{ColIdTechnology}";

        // Post Requests
        private static readonly string ReqCreate = $@"insert into {TableName}({ColIdProject},{ColIdTechnology}) 
                                                    values(@{ColIdProject},@{ColIdTechnology})";
        
        // Delete Requests
        private static readonly string ReqDelete = $@"delete from {TableName} 
                                                    where {ColIdProject} = @{ColIdProject} and 
                                                    {ColIdTechnology} = @{ColIdTechnology}";
    }
}