using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TaskList
{
    public class TodayTasksVM
    {
        public List<Project> ProjectsList { set; get; }
        public List<ToDoTask> UntagedTasksList { get; set; }
        public int ProjectsListHeight { get; set; }
        public int TaskListHeight { get; set; }

        public TodayTasksVM()
        {
            ProjectsList = new List<Project> {
                new Project ("Alfa", "A", "#4dd08a") {
                    new ToDoTask("Amelia", "Cedar cheese", "#3ec2f4", true, new DateTime(2018,4,25)),
                    new ToDoTask("Alfie", "Spruce sauce", "#3ec2f4", false, new DateTime(2018,5,29)),
                    new ToDoTask("Ava", "Pine apple", "#3ec2f4", false, new DateTime(2018,7,8)),
                    new ToDoTask("Archie", "Maple cake", "#3ec2f4", true, new DateTime(2018,6,1))
                },
                new Project ("Bravo", "B", "#68cdbf") {
                    new ToDoTask("Brooke", "Lumia phone", "#3ec2f4", false, new DateTime(2018,8,1)),
                    new ToDoTask("Bobby", "Xperia X7", "#3ec2f4", false, new DateTime(2018,9,8)),
                    new ToDoTask("Bella", "Desire Aspire", "#3ec2f4", false, new DateTime(2018,9,20)),
                    new ToDoTask("Ben", "Chocolate bars", "#3ec2f4", true, new DateTime(2018,8,5))
                }
            };

            int tasks = 0;
            int projects = 0;
            foreach (Project proj in ProjectsList)
            {
                tasks += proj.Count;
                projects++;
            }
            ProjectsListHeight = tasks * 90 + projects * 70 + 10;

            UntagedTasksList = new List<ToDoTask> {
                new ToDoTask("Celer", "Spruce sauce", "#b6ffb4", false, new DateTime(2018,5,29)),
                new ToDoTask("Cicka", "Pine apple", "#b3ffed", false, new DateTime(2018,7,8)),
                new ToDoTask("Capr", "Maple cake", "#fff7b5", true, new DateTime(2018,6,1))
            };
            TaskListHeight = UntagedTasksList.Count * 90;
        }
    }
}
