using Domain;

namespace Application.Security.Models
{
    public class AuthenticateResponse
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
        public string ProfilePicture { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            Firstname = user.Firstname;
            Lastname = user.Lastname;
            Email = user.Email;
            Role = user.Role;
            ProfilePicture = user.ProfilePicture;
            Token = token;
        }
    }
}