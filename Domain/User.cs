using System;
using System.Text.Json.Serialization;

namespace Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
        public DateTime Birthdate { get; set; }
        
        [JsonIgnore]
        public string Password { get; set; }

        public string ProfilePicture { get; set; }
    }
}
