using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Security.Models;
using Infrastructure.SqlServer.Repositories.User;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly AppSettings _appSettings;

        public UserService(
            IUserRepository userRepository,
            IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _appSettings = appSettings.Value;
        }

        // Authentication
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _userRepository.GetByEmail(model.Email);

            // Return null if user not found
            if (user == null) return null;

            if (!user.Password.Equals(model.Password)) return null;

            // Authentication successful so generate jwt token
            var token = GenerateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }
        
        private string GenerateJwtToken(Domain.User user)
        {
            // Generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler(); // Used to create the token
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret); // Get the key to generate the token
            var tokenDescriptor = new SecurityTokenDescriptor // Placeholder for the token's attributes
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }), // Who ?
                Expires = DateTime.UtcNow.AddDays(7), // Until when ?
                SigningCredentials = new SigningCredentials( // The token's "ID card"
                                        new SymmetricSecurityKey(key), 
                                        SecurityAlgorithms.HmacSha256Signature
                                     )
            };
            var token = tokenHandler.CreateToken(tokenDescriptor); // Creation of the token
            return tokenHandler.WriteToken(token); // Writing the token into a JSON format
        }
        
        // Requests
        public Domain.User GetById(int id)
        {
            return _userRepository.GetById(id);
        }
    }
}