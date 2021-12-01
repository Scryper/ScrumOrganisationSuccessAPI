namespace Application.UseCases.User.Dtos
{
    public class InputDtoUpdateUserPseudo
    {
        public int Id { get; set; }
        public User InternUser { get; set; }

        public class User
        {
            public string Pseudo { get; set; }
        }
    }
}