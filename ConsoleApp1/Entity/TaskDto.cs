using System;

namespace Acme.SimpleTaskApp.Tasks
{
    public class TaskDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int State { get; set; }

        public DateTime CreationTime { get; set;}
    }
}