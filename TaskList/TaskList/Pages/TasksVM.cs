using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;

namespace TaskList
{
    public class TasksVM : MyVM
    {
        public ObservableCollection<ToDoTask> UntagedTasksList { get; set; }

        private int _taskListHeight { get; set; }
        public int TaskListHeight
    {
            get => _taskListHeight;
            set
            {
                _taskListHeight = value;
                OnPropertyChanged("TaskListHeight");
            }
        }

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

        public void GetDataFromDb()
        {
            UntagedTasksList = new ObservableCollection<ToDoTask>();
            App.Database.GetItemsAsync<ToDoTask>().Result.ForEach(x => UntagedTasksList.Add(x));
            DebugUntagedTasksList();
            TaskListHeight = UntagedTasksList.Count * 90 + 90;
            OnPropertyChanged("UntagedTasksList");
        }
        public TasksVM()
        {
            GetDataFromDb();
        }
        public void DebugUntagedTasksList()
        {
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");

            Debug.WriteLine(UntagedTasksList.Count);
            foreach (ToDoTask todoItem in UntagedTasksList)
            {
                Debug.WriteLine(todoItem);
            }

            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");
        }
    }
}
