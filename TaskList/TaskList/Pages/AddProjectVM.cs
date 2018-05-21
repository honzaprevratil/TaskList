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
                new ToDoTask("Amelia", "Cedar cheese", "#b4b3ff", true, new DateTime(2018,4,25)),
                new ToDoTask("Alfie", "Spruce sauce", "#b6ffb4", false, new DateTime(2018,5,29)),
                new ToDoTask("Brooke", "Lumia phone", "#ffb3fd", false, new DateTime(2018,8,1)),
                new ToDoTask("Bobby", "Xperia X7", "#ffb3b3", false, new DateTime(2018,9,8)),
                new ToDoTask("Bella", "Desire Aspire", "#ffb3fd", false, new DateTime(2018,9,20)),
                new ToDoTask("Ben", "Chocolate bars", "#ffb3b3", true, new DateTime(2018,8,5)),
                new ToDoTask("Celer", "Spruce sauce", "#b6ffb4", false, new DateTime(2018,5,29)),
                new ToDoTask("Cicka", "Pine apple", "#b3ffed", false, new DateTime(2018,7,8)),
                new ToDoTask("Cicka", "Pine apple", "#b3ffed", false, new DateTime(2018,7,8)),
                new ToDoTask("Cicka", "Pine apple", "#b3ffed", false, new DateTime(2018,7,8)),
                new ToDoTask("Cicka", "Pine apple", "#b3ffed", false, new DateTime(2018,7,8)),
                new ToDoTask("Capr", "Maple cake", "#fff7b5", true, new DateTime(2018,6,1))
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
