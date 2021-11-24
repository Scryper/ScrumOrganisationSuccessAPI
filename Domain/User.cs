using System.Text.Json.Serialization;

namespace Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
        
        [JsonIgnore]
        public string Password { get; set; }
    }
}
