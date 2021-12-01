namespace Application.UseCases.UserStory.Dtos
{
    public class InputDtoUpdateUserStoryIsDone
    {
        public int Id { get; set; }
        public UserStory InternUserStory { get; set; }

        public class UserStory
        {
            public bool IsDone { get; set; }
        }
    }
}