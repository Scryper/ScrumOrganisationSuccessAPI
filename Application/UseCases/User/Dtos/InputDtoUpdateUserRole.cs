namespace Application.UseCases.User.Dtos
{
    public class InputDtoUpdateUserRole
    {
        public int Id { get; set; }

        public User InternUser { get; set; }

        public class User
        {
            public int Role { get; set; }
        }
    }
}