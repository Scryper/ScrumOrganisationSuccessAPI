using System;

namespace Domain
{
    public class Meeting
    {
        public int Id { get; set; }
        public int IdSprint { get; set; }
        public DateTime Schedule { get; set; }
        public string Description { get; set; }
        public string MeetingUrl { get; set; }

        protected bool Equals(Meeting other)
        {
            return IdSprint == other.IdSprint && Schedule.Equals(other.Schedule) && Description == other.Description && MeetingUrl == other.MeetingUrl;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Meeting) obj);
        }
    }
}
