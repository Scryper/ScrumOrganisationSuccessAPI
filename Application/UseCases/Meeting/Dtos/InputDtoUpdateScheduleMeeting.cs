using System;

namespace Application.UseCases.Meeting.Dtos
{
    public class InputDtoUpdateScheduleMeeting
    {
        public int Id { get; set; }
        public Meeting InternMeeting { get; set; }
        
        public class Meeting
        {
            public DateTime Schedule { get; set; }
        } 
    }
}