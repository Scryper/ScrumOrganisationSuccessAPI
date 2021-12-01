using Domain;

namespace Application.Security.Models
{
    public class AuthenticateResponse
    {
        private string Pseudo { get; set; }
        private string Email { get; set; }
        private int Role { get; set; }
        private string Token { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            Pseudo = user.Pseudo;
            Email = user.Email;
            Role = user.Role;
            Token = token;
        }
    }
}