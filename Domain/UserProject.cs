using System;

namespace Domain
{
    public class UserProject
    {
        public int IdDeveloper { get; set; }
        public int IdProject { get; set; }
        public bool IsAppliance { get; set; }

        protected bool Equals(UserProject other)
        {
            return IdDeveloper == other.IdDeveloper && IdProject == other.IdProject;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UserProject) obj);
        }
    }
}