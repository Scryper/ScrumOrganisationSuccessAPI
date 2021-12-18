using System;

namespace Application.UseCases.Meeting.Dtos
{
    // Output file : what we receive when reading in database
    public class OutputDtoMeeting
    {
        public int Id { get; set; }
        public int IdSprint { get; set; }
        public DateTime Schedule { get; set; }
        public string Description { get; set; }
        public string MeetingUrl { get; set; }
    }
}