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
    }
}
