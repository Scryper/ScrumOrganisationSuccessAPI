using Domain;

namespace Application.Security.Models
{
    // Represent the user, when he is authenticated.
    // The user in the database is different from the user in the different login sessions
    // the user in login sessions will have his token, along with all his other attributes
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
        public string ProfilePicture { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            Firstname = user.Firstname;
            Lastname = user.Lastname;
            Email = user.Email;
            Role = user.Role;
            ProfilePicture = user.ProfilePicture;
            Token = token;
        }
    }
}