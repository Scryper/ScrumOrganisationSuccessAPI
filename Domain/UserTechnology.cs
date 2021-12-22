using System;

namespace Domain
{
    public class UserTechnology
    {
        public int IdUser { get; set; }
        public int IdTechnology { get; set;}

        protected bool Equals(UserTechnology other)
        {
            return IdUser == other.IdUser && IdTechnology == other.IdTechnology;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UserTechnology) obj);
        }
    }
}