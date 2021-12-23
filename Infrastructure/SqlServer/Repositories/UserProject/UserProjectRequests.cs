namespace Infrastructure.SqlServer.Repositories.UserProject
{
    public partial class UserProjectRepository
    {
        public const string TableName = "user_project";
        public const string TableProject = "project";
        public const string ColIdProjectFromProject = "id";
        public const string ColStatusProject = "sos_status";
        public const string ColIdUser = "id_user";
        public const string ColIdProject = "id_project";
        public const string ColIsAppliance = "is_appliance";


        // Get requests
        private static readonly string ReqGetAll = $"select * from {TableName}";
        
        private static readonly string ReqGetByDeveloperId = $@"select * from {TableName} 
                                                              where {ColIdUser} = @{ColIdUser}";
        
        //use to get the project of a dev if he works on it and if the project is not over yet
        private static readonly string ReqByIdDeveloperIsAppliance = $@"select {ColIdUser}, {ColIdProject}, {ColIsAppliance} 
                                                                        from {TableName} inner join {TableProject} on 
                                                                        {TableName}.{ColIdProject} = {TableProject}.{ColIdProjectFromProject} 
                                                                        where {ColIdUser} = @{ColIdUser} and 
                                                                        {ColIsAppliance} = 0 and 
                                                                        {ColStatusProject} = 2";

        //use to get the list of devprojects of a dev if he works on it
        private static readonly string ReqDeveloperProjectByIdDeveloperIfIsWorking = $@"select {ColIdUser}, {ColIdProject}, {ColIsAppliance} from {TableName} 
                                                                        where {ColIdUser} = @{ColIdUser} and 
                                                                        {ColIsAppliance} = 0";
        
        //use to get the list of devproject of a dev if he doen't works on it
        private static readonly string ReqDeveloperProjectByIdDeveloperifIsNotWorking = $@"select {ColIdUser}, {ColIdProject}, {ColIsAppliance} from {TableName} 
                                                                        where {ColIdUser} = @{ColIdUser} and 
                                                                        {ColIsAppliance} = 1";

        private static readonly string ReqGetByIdDeveloperIdProject = $@"select * from {TableName} 
                                                                        where {ColIdUser} = @{ColIdUser} and 
                                                                        {ColIdProject} = @{ColIdProject}";

        // Post requests
        private static readonly string ReqCreate = $@"insert into {TableName}({ColIdUser},{ColIdProject},{ColIsAppliance}) 
                                                    values(@{ColIdUser}, @{ColIdProject}, @{ColIsAppliance})";

        // Put requests
        private static readonly string ReqUpdate = $@"update {TableName} 
                                                    set {ColIsAppliance} = @{ColIsAppliance} 
                                                    where {ColIdUser} = @{ColIdUser} and 
                                                    {ColIdProject} = @{ColIdProject}";
        
        // Delete requests
        private static readonly string ReqDelete = $@"delete from {TableName} 
                                                    where {ColIdUser} = @{ColIdUser} and 
                                                    {ColIdProject} = @{ColIdProject}";
    }
}