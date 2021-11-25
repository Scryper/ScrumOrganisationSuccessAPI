namespace Application.UseCases.Project.Dtos
{
    public class InputDtoUpdateProjectRepositoryUrl
    {
        public int Id { get; set; }
        public Project InternProject { get; set; }

        public class Project
        {
            public string RepositoryUrl { get; set; }
        }
    }
}