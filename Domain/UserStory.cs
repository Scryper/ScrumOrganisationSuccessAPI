﻿namespace Domain
{
    public class UserStory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public int IdProject { get; set; }
    }
}
