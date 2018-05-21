using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            UntagedTasksList = App.Database.GetItemsAsync<ToDoTask>().Result;
            DebugData(UntagedTasksList);
            TaskListHeight = UntagedTasksList.Count * 90 + 90;
        }
        public void DebugData(List<ToDoTask> ItemsToPrint)
        {
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");

            Debug.WriteLine(ItemsToPrint.Count);
            foreach (ToDoTask todoItem in ItemsToPrint)
            {
                Debug.WriteLine(todoItem);
            }

            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");
        }
    }
}
