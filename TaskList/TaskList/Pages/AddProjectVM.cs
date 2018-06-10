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

        public void LoadProject(Project project)
        {
            ProjectId = project.ProjectId;
            Name = project.Name;
            Text = project.Description;
            var color = Colors.Where(x => x.HexColor == project.HexColor).ToList();
            SelectedColor = color.Count == 0 ? null : color[0];

            UntagedTasksList = App.Database.GetItemsAsync<ToDoTask>().Result.ToList();
            UntagedTasksList.ForEach(x => x.IsInProject = false);
            
            // in new Project: all tasks will be UNCHECKED
            // in existing Project: all tasks that belong to this project will be CHECKED
            UntagedTasksList.Where(x => x.ProjectId == this.ProjectId && x.ProjectId != 0).ToList().ForEach(x => x.IsInProject = true);

            // in new Project: all tasks, that are not in project will be CHECKED
            // in existing Project: all tasks that belong to this project will be CHECKED
            //UntagedTasksList.Where(x => x.ProjectId == this.ProjectId).ToList().ForEach(x => x.IsInProject = true);

            TaskListHeight = UntagedTasksList.Count * 45;
        }
        public bool SaveProjectIfValid()
        {
            /*Console.WriteLine("   ");
            Console.WriteLine(Name);
            Console.WriteLine(Text);
            Console.WriteLine("   ");*/

            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Text) && SelectedColor != null)
            {
                ToDoProject returnProject = new ToDoProject(Name, Text, SelectedColor.HexColor) { ID = this.ProjectId };
                int doneOrNot = App.Database.SaveItemAsync(returnProject).Result;
                this.ProjectId = App.Database.GetItemsAsync<ToDoProject>().Result.Where(x => x.Name == Name && x.HexColor == SelectedColor.HexColor && x.Description == Text).ToList()[0].ID;

                foreach (ToDoTask task in UntagedTasksList)
                {
                    if (task.IsInProject == true)
                    {
                        task.IsInProject = false;
                        task.ProjectId = this.ProjectId;
                        App.Database.SaveItemAsync(task);
                    }
                    else if (task.ProjectId == this.ProjectId)
                    {
                        task.ProjectId = 0;
                        App.Database.SaveItemAsync(task);
                    }
                }

                return true;
            }
            return false;
        }
        public AddProjectVM()
        {
            Colors = new List<Color> {
                new Color("Pink","#F48FB1"),
                new Color("Purple","#B39DDB"),
                new Color("Blue","#90CAF9"),
                new Color("Green","#A5D6A7"),
                new Color("Lime","#E6EE9C"),
                new Color("Yellow","#FFF59D"),
                new Color("Orange","#FFCC80"),
                new Color("Gray","#EEEEEE"),
            };
            ColorsListHeight = (Colors.Count + 1) * 40 + 5;
        }
    }
}
