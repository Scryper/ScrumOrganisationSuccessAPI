using System;

namespace Application.UseCases.Project.Dtos
{
    // Input file : what we need to add in the database
    public class InputDtoProject
    {
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }
        public string RepositoryUrl { get; set; }
        public int Status { get; set; }
    }
}