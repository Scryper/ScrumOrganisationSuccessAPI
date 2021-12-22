using System;

namespace Domain
{
    public class Participation
    {
        public int IdUser { get; set; }
        public int IdMeeting { get; set; }

        protected bool Equals(Participation other)
        {
            return IdUser == other.IdUser && IdMeeting == other.IdMeeting;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Participation) obj);
        }
    }
}