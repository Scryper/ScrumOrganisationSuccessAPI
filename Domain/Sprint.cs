using System;

namespace Domain
{
    public class Sprint
    {
        public int Id { get; set; }
        public int SprintNumber { get; set; }
        public int IdProject { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public int Progression { get; set; }
    }
}
