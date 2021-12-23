using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Security.Models;
using Domain;
using Infrastructure.SqlServer.Repositories.Sprint;
using Infrastructure.SqlServer.Repositories.User;
using Infrastructure.SqlServer.Repositories.UserProject;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserProjectRepository _userProjectRepository;
        private readonly ISprintRepository _sprintRepository;
        private readonly AppSettings _appSettings;

        public UserService(IUserRepository userRepository, 
            IUserProjectRepository userProjectRepository,
            ISprintRepository sprintRepository,
            IOptions<AppSettings> appSettings) {
            _userRepository = userRepository;
            _userProjectRepository = userProjectRepository;
            _sprintRepository = sprintRepository;
            _appSettings = appSettings.Value;
        }

        // Authentication
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            // To authenticate a user, we first check if the user is registered in the database
            // this verification is based on if the email address is in the databse
            // we know it's him because we do not allow duplicate emails (see User.cs => Equals)
            var user = _userRepository.GetByEmail(model.Email);
            
            // Return null if user not found
            if (user == null) return null;

            // Verify the password using hash
            if (!BCrypt.Net.BCrypt.Verify(model.Password, user.Password)) return null;

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
        
        // Compute experience
        // The user's experience is equal to the addition of the length of the different sprints of the different
        // projects he worked on
        public int ComputeDaysOfExperience(int id)
        {
            List<UserProject> userProjects = _userProjectRepository.GetByIdDeveloper(id); 
            List<TimeSpan> timeSpans = new List<TimeSpan>();
            foreach (UserProject up in userProjects)
            {
                List<Domain.Sprint> sprintsTemp = _sprintRepository.GetByIdProject(up.IdProject);
                foreach (Domain.Sprint tmp in sprintsTemp)
                {
                    timeSpans.Add(tmp.GetSprintDuration());
                }
            }
            
            return _userRepository.GetById(id).GetDaysOfWork(timeSpans);
        }
    }
}