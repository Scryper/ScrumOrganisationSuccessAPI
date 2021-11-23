namespace Application.UseCases.User.Dtos
{
    // Output file : what we receive when reading in database
    public class OutputDtoUser
    {
        public int Id { get; set; }
        public string Pseudo { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
    }
}