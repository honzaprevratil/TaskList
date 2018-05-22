using System;
using System.Collections.Generic;
using System.Text;

namespace TaskList
{
    public class AddProjectVM : MyVM
    {
        public List<Color> Colors { get; set; }
        public int ColorsListHeight { get; set; }
        public List<ToDoTask> UntagedTasksList { get; set; }
        public int TaskListHeight { get; set; }

        public AddProjectVM()
        {
            UntagedTasksList = new List<ToDoTask> {
                new ToDoTask("Asr", "Spruce sauce", new DateTime(2018,5,29), new DateTime(2018,5,29), 5, "#b6ffb4", false, true),
                new ToDoTask("Amel alir", "Pine apple", new DateTime(2018,7,8), new DateTime(2018,7,8), 4, "#b3ffed", true, true),
                new ToDoTask("Amand", "Maple cake", new DateTime(2018,6,1), new DateTime(2018,6,1), 2, "#fff7b5", true, true),
                new ToDoTask("Bilk", "Yaa sauce", new DateTime(2018,5,29), new DateTime(2018,5,29), 5, "#b6ffb4", true, true),
                new ToDoTask("Balon", "Pine apple", new DateTime(2018,7,8), new DateTime(2018,7,8), 4, "#b3ffed", false, true),
                new ToDoTask("Bark", "Sik cake", new DateTime(2018,6,1), new DateTime(2018,6,1), 2, "#fff7b5", true, true),
                new ToDoTask("Asr", "Spruce sauce", new DateTime(2018,5,29), new DateTime(2018,5,29), 5, "#b6ffb4", false, true),
                new ToDoTask("Amel alir", "Pine apple", new DateTime(2018,7,8), new DateTime(2018,7,8), 4, "#b3ffed", true, true),
                new ToDoTask("Amand", "Maple cake", new DateTime(2018,6,1), new DateTime(2018,6,1), 2, "#fff7b5", true, true),
                new ToDoTask("Bilk", "Yaa sauce", new DateTime(2018,5,29), new DateTime(2018,5,29), 5, "#b6ffb4", true, true),
                new ToDoTask("Balon", "Pine apple", new DateTime(2018,7,8), new DateTime(2018,7,8), 4, "#b3ffed", false, true),
                new ToDoTask("Bark", "Sik cake", new DateTime(2018,6,1), new DateTime(2018,6,1), 2, "#fff7b5", true, true),
            };
            TaskListHeight = UntagedTasksList.Count * 45;

            Colors = new List<Color> {
                new Color("Red","#ffb3b3"),
                new Color("Pink","#ffb3fd"),
                new Color("Purple","#b4b3ff"),
                new Color("Blue","#b3ffed"),
                new Color("Green","#b6ffb4"),
                new Color("Yellow","#fff7b5"),
            };
            ColorsListHeight = Colors.Count * 36 + 2;
        }
    }
}
