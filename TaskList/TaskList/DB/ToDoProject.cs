using System;
using System.Collections.Generic;
using System.Text;
using TaskList.DB;

namespace TaskList
{
    public class ToDoProject : ATable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string HexColor { get; set; }

        public ToDoProject(string name, string description, string hexColor)
        {
            Name = name;
            Description = description;
            HexColor = hexColor;
        }
        public ToDoProject() { }
        public override string ToString()
        {
            return "ID" + ID + " Name " + Name + " Text " + Description;
        }
    }
}
