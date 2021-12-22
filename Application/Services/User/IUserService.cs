using Application.Security.Models;

namespace Application.Services.User
{
    public interface IUserService
    {
        // Authentication
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        
        // Requests
        public Domain.User GetById(int id);
        
        // Other
        public int ComputeDaysOfExperience(int id);
    }
}