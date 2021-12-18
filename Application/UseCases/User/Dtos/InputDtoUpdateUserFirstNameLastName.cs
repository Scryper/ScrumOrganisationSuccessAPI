namespace Application.UseCases.User.Dtos
{
    public class InputDtoUpdateUserFirstNameLastName
    {
        public int Id { get; set; }
        public User InternUser { get; set; }

        public class User
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}