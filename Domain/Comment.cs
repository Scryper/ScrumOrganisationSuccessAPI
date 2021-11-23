using System;

namespace Domain
{
    public class Comment
    {
        public int Id { get; set; }
        public int IdUserStory { get; set; }
        public int IdUser { get; set; }
        public DateTime PostedAt { get; set; }
        public string Content { get; set; }
    }
}
