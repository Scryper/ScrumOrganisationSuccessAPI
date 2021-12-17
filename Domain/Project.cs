using System;

namespace Domain
{
    public class Project
    {
        public int Id { get; set; }
        public int IdProductOwner { get; set; }
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }
        public string RepositoryUrl { get; set; }
        public int Status { get; set; }
    }
}
