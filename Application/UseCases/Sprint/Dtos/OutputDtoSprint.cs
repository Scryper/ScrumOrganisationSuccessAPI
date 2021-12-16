using System;

namespace Application.UseCases.Sprint.Dtos
{
    // Output file : what we receive when reading in database
    public class OutputDtoSprint
    {
        public int Id { get; set; }
        public int IdProject { get; set; }
        public int SprintNumber { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime StartDate { get; set; }
    }
}