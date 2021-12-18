namespace Application.UseCases.Project.Dtos
{
    public class InputDtoUpdateProjectStatus
    {
        public int Id { get; set; }
        public Project InternProject { get; set; }

        public class Project
        {
            public int Status { get; set; }
        }
    }
}