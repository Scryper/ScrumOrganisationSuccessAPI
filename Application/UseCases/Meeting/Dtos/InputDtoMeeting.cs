using System;

namespace Application.UseCases.Meeting.Dtos
{
    // Input file : what we need to add in the database
    public class InputDtoMeeting
    {
        public int IdSprint { get; set; }
        public DateTime Schedule { get; set; }
        
        public string Description { get; set; }
        
        public string MeetingUrl { get; set; }
    }
}