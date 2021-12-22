using System;

namespace Domain
{
    public class UserStory
    {
        public int Id { get; set; }
        public int IdProject { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }

        protected bool Equals(UserStory other)
        {
            return IdProject == other.IdProject && Name == other.Name && Description == other.Description && Priority == other.Priority;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UserStory) obj);
        }
    }
}
