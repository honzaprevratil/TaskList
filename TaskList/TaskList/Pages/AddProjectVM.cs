using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskList
{
    public class AddProjectVM : MyVM
    {
        public int ProjectId { get; set; } = 0;
        public string Name { get; set; }
        public string Text { get; set; }

        public List<Color> Colors { get; set; }
        public Color SelectedColor { get; set; }
        public int ColorsListHeight { get; set; }

        public List<ToDoTask> UntagedTasksList { get; set; }
        public int TaskListHeight { get; set; }

        public void LoadProject(ToDoProject project)
        {
            ProjectId = project.ID;
            Name = project.Name;
            Text = project.Description;
            var color = Colors.Where(x => x.HexColor == project.HexColor).ToList();
            SelectedColor = color.Count == 0 ? null : color[0];
        }
        public bool SaveProjectIfValid()
        {
            Console.WriteLine("   ");
            Console.WriteLine(Name);
            Console.WriteLine(Text);
            Console.WriteLine("   ");

            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Text) && SelectedColor != null)
            {
                ToDoProject returnTask = new ToDoProject(Name, Text, SelectedColor.HexColor) { ID = ProjectId };
                App.Database.SaveItemAsync(returnTask);
                return true;
            }
            return false;
        }
        public AddProjectVM()
        {
            UntagedTasksList = App.Database.GetItemsAsync<ToDoTask>().Result.Where(x => x.ProjectId > 0).ToList();
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
