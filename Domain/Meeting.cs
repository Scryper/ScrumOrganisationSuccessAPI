using System;

namespace Domain
{
    public class Meeting
    {
        public int Id { get; set; }
        public int IdSprint { get; set; }
        public DateTime Schedule { get; set; }
        public string Description { get; set; }
        public string MeetingUrl { get; set; }
        
    }
}
