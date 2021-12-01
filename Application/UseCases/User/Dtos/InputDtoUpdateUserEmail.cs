namespace Application.UseCases.User.Dtos
{
    public class InputDtoUpdateUserEmail
    {
        public int Id { get; set; }
        public User InternUser { get; set; }

        public class User
        {
            public string Email { get; set; }
        }
    }
}