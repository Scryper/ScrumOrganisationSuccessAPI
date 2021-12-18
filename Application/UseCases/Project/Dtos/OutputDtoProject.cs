using System;

namespace Application.UseCases.Project.Dtos
{
    // Output file : what we receive when reading in database
    public class OutputDtoProject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }
        public string RepositoryUrl { get; set; }
        public int Status { get; set; }
    }
}