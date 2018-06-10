using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace TaskList
{
    public class TodayTasksVM : MyVM
    {
        public TasksVM TasksVM { get; set; } = new TasksVM();
        public ProjectsVM ProjectsVM { get; set; } = new ProjectsVM() { onlyTodayTasks = true };
        public List<ToDoTask> AllToDoTasks = new List<ToDoTask>();
        public bool AllTasksDone { get; set; }

        public void GetDataFromDb ()
        {
            AllToDoTasks.Clear();
            App.Database.GetItemsAsync<ToDoTask>().Result
                .Where(x => DateTime.Compare(x.StartDate, DateTime.Now) <= 0 &&
                            ((x.Done && x.DoneDate.Date == DateTime.Now.Date) || !x.Done)
                        ).ToList()
                .ForEach(x => AllToDoTasks.Add(x));

            AllTasksDone = (TasksToDo == ("0 / " + AllToDoTasks.Count()) ) ? true : false;

            OnPropertyChanged("AllTasksDone");
            OnPropertyChanged("HoursToDo");
            OnPropertyChanged("TasksToDo");

            TasksVM.GetDataFromDb(true);
            ProjectsVM.GetDataFromDb();
            ProjectsVM.UpdateListContent();
        }

        public string HoursToDo
        {
            get
            {
                int hoursToDo = 0;
                int allHours = 0;

                AllToDoTasks
                    .Where(x => !x.Done).ToList() // if not done
                    .ForEach(x => hoursToDo += x.EstimatedTime); //add EstimatedTime
                AllToDoTasks.ForEach(x => allHours += x.EstimatedTime);
                return hoursToDo + " / " + allHours;
            }
        }
        public string TasksToDo
        {
            get
            {
                int undone = AllToDoTasks.Where(x => !x.Done).Count(); // if not done
                int all = AllToDoTasks.Count();
                return undone + " / " + all;
            }
        }
    }
}
