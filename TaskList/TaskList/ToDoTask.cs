using System;
using System.Collections.Generic;
using System.Text;
using TaskList.DB;

namespace TaskList
{
    public class ToDoTask : ATable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Deadline { get; set; }
        public int EstimatedTime { get; set; }
        public string HexColor { get; set; }
        public bool Done { get; set; }
        public bool IsInProject { get; set; }

        public ToDoTask(string name, string description, string hexColor, bool done, DateTime deadLine)
        {
            Name = name;
            Description = description;
            HexColor = hexColor;
            Done = done;
            Deadline = deadLine;
        }

        public ToDoTask() { }
        public override string ToString()
        {
            return "ID" + ID + " Name " + Name + " Text " + Description;
        }
    }
}
