using System;

namespace Domain
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }
        public string RepositoryUrl { get; set; }
        public int Status { get; set; }

        protected bool Equals(Project other)
        {
            return Name == other.Name && Description == other.Description && RepositoryUrl == other.RepositoryUrl;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Project) obj);
        }
    }
}
