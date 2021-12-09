using Domain;

namespace Application.Security.Models
{
    public class AuthenticateResponse
    {
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            Pseudo = user.Pseudo;
            Email = user.Email;
            Role = user.Role;
            Token = token;
        }
    }
}