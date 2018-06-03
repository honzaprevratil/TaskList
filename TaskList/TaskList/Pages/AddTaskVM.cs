using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskList
{
    public class AddTaskVM : MyVM
    {
        public int TaskId { get; set; } = 0;
        public string Name { get; set; }
        public string Text { get; set; }
        public bool Done { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Today;
        public DateTime Deadline { get; set; } = DateTime.Today;

        private double _estimatedTime = 1;
        public double EstimatedTime
        {
            get => _estimatedTime;
            set
            {
                _estimatedTime = value;
                OnPropertyChanged("EstimatedTime");
            }
        }
        public List<Color> Colors { get; set; }
        public Color SelectedColor { get; set; } = null;

        public int ColorsListHeight { get; set; }
        public List<ToDoProject> AllProjects { get; set; } = new List<ToDoProject>();
        public ToDoProject SelectedProject { get; set; } = null;


        public void LoadTask(ToDoTask task)
        {
            TaskId = task.ID;
            Name = task.Name;
            Text = task.Description;
            Done = task.Done;
            StartDate = DateTime.Compare(task.StartDate, DateTime.Today.AddYears(-100)) < 0 ? DateTime.Today : task.StartDate;
            Deadline = DateTime.Compare(task.Deadline, DateTime.Today.AddYears(-100)) < 0 ? DateTime.Today : task.Deadline;
            EstimatedTime = task.EstimatedTime;
            Console.WriteLine("EstimatedTime: " + EstimatedTime);

            var project = AllProjects.Where(x => x.ID == task.ProjectId).ToList();
            SelectedProject = (project.Count > 0) ? project[0] : null;

            var color = Colors.Where(x => x.HexColor == task.HexColor).ToList();
            SelectedColor = (color.Count > 0) ? color[0] : null;
        }

        public AddTaskVM()
        {
            Colors = new List<Color> {
                new Color("Red","#ffb3b3"),
                new Color("Pink","#ffb3fd"),
                new Color("Purple","#b4b3ff"),
                new Color("Blue","#b3ffed"),
                new Color("Green","#b6ffb4"),
                new Color("Yellow","#fff7b5"),
            };
            ColorsListHeight = Colors.Count * 36 + 2;

            AllProjects.Clear();
            AllProjects.Add(new ToDoProject() { ID = 0, Name = "No project" });
            SelectedProject = AllProjects[0];
            App.Database.GetItemsAsync<ToDoProject>().Result.ToList().ForEach(x => AllProjects.Add(x));
        }
        public bool SaveTaskIfValid()
        {
            /*Console.WriteLine("   ");
            Console.WriteLine(Name);
            Console.WriteLine(Text);
            Console.WriteLine(StartDate.ToLongDateString());
            Console.WriteLine(Deadline.ToLongDateString());
            Console.WriteLine("   ");*/

            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Text) && SelectedColor != null)
            {
                ToDoTask returnTask = new ToDoTask(Name, Text, StartDate, Deadline, (int)Math.Round(EstimatedTime, 0), SelectedColor.HexColor, Done, false) { ID = TaskId };

                if (SelectedProject != null)
                {
                    returnTask.ProjectId = SelectedProject.ID;
                }

                App.Database.SaveItemAsync(returnTask);
                return true;
            }
            return false;
        }
    }
}
