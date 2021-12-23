using System;
using System.Collections.Generic;
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

        public int GetDaysOfWork(List<TimeSpan> timeSpans)
        {
            TimeSpan tmp = new TimeSpan(0,0,0,0);
            foreach (TimeSpan duration in timeSpans)
            {
                tmp += duration;
            }
            return tmp.Days;
        }

        protected bool Equals(User other)
        {
            return Email == other.Email;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((User) obj);
        }
    }
}
