using System;

namespace Application.UseCases.User.Dtos
{
    // Input file : what we need to add in the database
    public class InputDtoUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
        public DateTime Birthdate { get; set; }
    }
}