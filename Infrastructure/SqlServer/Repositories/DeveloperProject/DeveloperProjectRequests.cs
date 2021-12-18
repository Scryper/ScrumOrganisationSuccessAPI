namespace Infrastructure.SqlServer.Repositories.DeveloperProject
{
    public partial class DeveloperProjectRepository
    {
        public const string TableName = "developer_project";
        public const string TableProject = "project";
        public const string ColIdProjectFromProject = "id";
        public const string ColStatusProject = "sos_status";
        public const string ColIdDeveloper = "id_developer";
        public const string ColIdProject = "id_project";
        public const string ColIsAppliance = "is_appliance";
        
        
        // Get requests
        private static readonly string ReqGetAll = $"select * from {TableName}";
        
        private static readonly string ReqGetByDeveloperId = $@"select * from {TableName} 
                                                              where {ColIdDeveloper} = @{ColIdDeveloper}";

        private static readonly string ReqGetByProjectId = $@"select * from {TableName} 
                                                            where {ColIdProject} = @{ColIdProject}";
        
        //use to get the project of a dev if he works on it and if the project is not over yet
        private static readonly string ReqByIdDeveloperIsAppliance = $@"select {ColIdDeveloper}, {ColIdProject}, {ColIsAppliance} 
                                                                        from {TableName} inner join {TableProject} on 
                                                                        {TableName}.{ColIdProject} = {TableProject}.{ColIdProjectFromProject} 
                                                                        where {ColIdDeveloper} = @{ColIdDeveloper} and 
                                                                        {ColIsAppliance} = 0 and 
                                                                        {ColStatusProject} = 2";

        //use to get the list of devprojects of a dev if he works on it
        private static readonly string ReqDeveloperProjectByIdDeveloperIfIsWorking = $@"select {ColIdDeveloper}, {ColIdProject}, {ColIsAppliance} from {TableName} 
                                                                        where {ColIdDeveloper} = @{ColIdDeveloper} and 
                                                                        {ColIsAppliance} = 0";
        
        //use to get the list of devproject of a dev if he doen't works on it
        private static readonly string ReqDeveloperProjectByIdDeveloperifIsNotWorking = $@"select {ColIdDeveloper}, {ColIdProject}, {ColIsAppliance} from {TableName} 
                                                                        where {ColIdDeveloper} = @{ColIdDeveloper} and 
                                                                        {ColIsAppliance} = 1";
        
        //use to get the list of projects on wich a dev is not working on
        /*private static readonly string ReqProjectsByIdDeveloperIfNoRelation = $@"select * from {TableProject} left join {TableName} 
                                                                                on {TableProject}.{ColIdProjectFromProject} = {TableName}.{ColIdProject} 
                                                                                where "
                                                                                */
        
        
        private static readonly string ReqGetByIdDeveloperIdProject = $@"select * from {TableName} 
                                                                        where {ColIdDeveloper} = @{ColIdDeveloper} and 
                                                                        {ColIdProject} = @{ColIdProject}";
        
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