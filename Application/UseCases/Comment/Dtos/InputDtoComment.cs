using System;

namespace Application.UseCases.Comment.Dtos
{
    // Input file : what we need to add in the database
    public class InputDtoComment
    {
        public int IdUserStory { get; set; }
        public int IdUser { get; set; }
        public DateTime PostedAt { get; set; }
        public string Content { get; set; }
    }
}