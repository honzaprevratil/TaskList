using System;
using System.Collections.Generic;
using System.Text;

namespace TaskList
{
    public class AddTaskVM : MyVM
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public bool Done { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Today;
        public DateTime Deadline { get; set; } = DateTime.Today;

        private double _estimatedTime = 1;
        public double EstimatedTime
        {
            get => Math.Round(_estimatedTime, 0);
            set
            {
                _estimatedTime = value;
                OnPropertyChanged("EstimatedTime");
            }
        }
        public List<Color> Colors { get; set; }
        public Color SelectedColor { get; set; }

        public int ColorsListHeight { get; set; }

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
        }
        public ToDoTask GetTaskToSave()
        {
            ToDoTask returnTask = new ToDoTask() { Name = Name, Description = Text };
            return returnTask;
        }
    }
}
