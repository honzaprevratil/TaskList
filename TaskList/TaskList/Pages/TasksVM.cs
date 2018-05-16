using System;
using System.Collections.Generic;
using System.Text;

namespace TaskList
{
    public class TasksVM : MyVM
    {
        public List<ToDoTask> UntagedTasksList { get; set; }
        public int TaskListHeight { get; set; }

        private ToDoTask _selectedTask = null;
        public ToDoTask SelectedTask
        {
            get => _selectedTask;
            set
            {
                _selectedTask = value;
                OnPropertyChanged("SelectedTask");
            }
        }

        public TasksVM()
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
            TaskListHeight = UntagedTasksList.Count * 90 + 90;
        }
    }
}
