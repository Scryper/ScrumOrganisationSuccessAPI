using System;

namespace Domain
{
    public class Sprint
    {
        public int Id { get; set; }
        public int IdProject { get; set; }
        public int SprintNumber { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime StartDate { get; set; }
        
        public TimeSpan GetSprintDuration()
        {
            return Deadline - StartDate;
        }

        protected bool Equals(Sprint other)
        {
            return IdProject == other.IdProject && Description == other.Description && Deadline.Equals(other.Deadline) && StartDate.Equals(other.StartDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Sprint) obj);
        }
    }
}
