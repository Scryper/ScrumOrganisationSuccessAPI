namespace Application.UseCases.User.Dtos
{
    public class InputDtoUpdateUserPassword
    {
        public int Id { get; set; }
        public User InternUser { get; set; }

        public class User
        {
            public string Password { get; set; }
        }
    }
}