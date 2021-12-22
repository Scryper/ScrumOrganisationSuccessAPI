using System;

namespace Domain
{
    public class SprintUserStory
    {
        public int IdSprint { get; set; }
        public int IdUserStory { get; set; }

        protected bool Equals(SprintUserStory other)
        {
            return IdSprint == other.IdSprint && IdUserStory == other.IdUserStory;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SprintUserStory) obj);
        }
    }
}