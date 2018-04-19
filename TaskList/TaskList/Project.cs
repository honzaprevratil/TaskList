using System;
using System.Collections.Generic;
using System.Text;

namespace TaskList
{
    public class Project : List<ToDoTask>
    {
        public string Name { get; set; }
        public string ShortName { get; set; } //will be used for jump lists
        public string Description { get; set; }
        public string HexColor { get; set; }
        public bool Done { get; set; }

        public Project(string name, string shortName, string hexColor)
        {
            Name = name;
            ShortName = shortName;
            HexColor = hexColor;
        }
    }
}
