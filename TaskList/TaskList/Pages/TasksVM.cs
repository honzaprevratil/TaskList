using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Linq;

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

        public void GetDataFromDb(bool OnlyTodayTasks = false)
        {
            UntagedTasksList = new ObservableCollection<ToDoTask>();
            if (OnlyTodayTasks)
            {
                App.Database.GetItemsAsync<ToDoTask>().Result
                    .Where(x => DateTime.Compare(x.StartDate, DateTime.Now) <= 0 && !x.Done && x.ProjectId == 0).ToList()
                    .ForEach(x => UntagedTasksList.Add(x));
            }
            else
                App.Database.GetItemsAsync<ToDoTask>().Result.ForEach(x => UntagedTasksList.Add(x));
            TaskListHeight = UntagedTasksList.Count * 90 + 80;
            OnPropertyChanged("UntagedTasksList");
        }
        public TasksVM()
        {
            GetDataFromDb();
        }
    }
}
