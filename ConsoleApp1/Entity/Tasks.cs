using ConsoleApp1.Utilty;
using System;
namespace Acme.SimpleTaskApp.Tasks
{
    [Serializable]
    public class Tasks
    {
        [DataField("Id")]
        public string Id { get; set; }

        [DataField("Title")]
        public string Title { get; set; }

        [DataField("Description")]
        public string Description { get; set; }

        [DataField("State")]
        public TaskState State { get; set; }

        public Tasks()
        {

        }

        public Tasks(string id, string title, string description, TaskState state)
            : this()
        {
            Id = id;
            Title = title;
            Description = description;
            State = state;
        }
    }

    public enum TaskState : byte
    {
        Open = 0,
        Completed = 1
    }

    public enum DescType: byte
    {
        A = 0,
        B = 1,
        C = 2,
        D = 3
    }
}