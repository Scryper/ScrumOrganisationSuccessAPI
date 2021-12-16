namespace Application.UseCases.UserStory.Dtos
{
    public class OutputDtoUserStory
    {
        // Output file : what we receive when reading in database
        public int Id { get; set; }
        public int IdProject { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
    }
}