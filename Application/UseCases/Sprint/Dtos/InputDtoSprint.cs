using System;

namespace Application.UseCases.Sprint.Dtos
{
    // Input file : what we need to add in the database
    public class InputDtoSprint
    {
        public int SprintNumber { get; set; }
        public int IdProject { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public int Progression { get; set; }
    }
}