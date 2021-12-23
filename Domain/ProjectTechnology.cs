using System;

namespace Domain
{
    public class ProjectTechnology
    {
        public int IdProject { get; set; }
        public int IdTechnology { get; set; }

        protected bool Equals(ProjectTechnology other)
        {
            return IdProject == other.IdProject && IdTechnology == other.IdTechnology;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ProjectTechnology) obj);
        }
    }
}