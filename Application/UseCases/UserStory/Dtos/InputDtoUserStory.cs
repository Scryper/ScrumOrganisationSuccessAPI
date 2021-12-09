namespace Application.UseCases.UserStory.Dtos
{
    public class InputDtoUserStory
    {
        // Input file : what we need to add in the database
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public int IdProject { get; set; }
        public int Priority { get; set; }
    }
}