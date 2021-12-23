namespace Application.UseCases.UserStory.Dtos
{
    public class InputDtoUpdateUserStory
    {
        public int Id { get; set; }
        public UserStory InternUserStory { get; set; }

        public class UserStory
        {
            public string Name { get; set; }
            
            public int IdProject { get; set; }
            public string Description { get; set; }
            public int Priority { get; set; }
        }
    }
}