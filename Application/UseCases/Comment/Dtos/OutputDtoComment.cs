using System;

namespace Application.UseCases.Comment.Dtos
{
    // Output file : what we receive when reading in database
    public class OutputDtoComment
    {
        public int Id { get; set; } 
        public int IdUserStory { get; set; }
        public int IdUser { get; set; }
        public DateTime PostedAt { get; set; }
        public string Content { get; set; }
    }
}