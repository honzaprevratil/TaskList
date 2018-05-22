using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace TaskList
{
    public class TodayTasksVM : MyVM
    {
        private List<Project> _allGroups { set; get; }

        public ObservableCollection<Project> ExpandedGroups { set; get; }
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

        private int _projectsListHeight;
        public int ProjectsListHeight
        {
            get => _projectsListHeight;
            set
            {
                _projectsListHeight = value;
                OnPropertyChanged("ProjectsListHeight");
            }
        }
        // Command with parameter
        public RelayCommand<Project> GroupClicked { get; }
        
        private void GroupClickedMethod(Project project)
        {
            int selectedIndex = ExpandedGroups.IndexOf(project);
            _allGroups[selectedIndex].Expanded = !(_allGroups[selectedIndex].Expanded);
            UpdateListContent();
        }

        private void UpdateListContent()
        {
            ExpandedGroups = new ObservableCollection<Project>();

            int tasks = 0;
            int projects = 0;

            foreach (Project group in _allGroups)
            {
                Project newGroup = new Project(group.Name, group.ShortName, group.HexColor, group.Description)
                {
                    Expanded = group.Expanded
                };
                projects++;

                if (group.Expanded)
                {
                    tasks += group.Count;
                    foreach (ToDoTask task in group)
                    {
                        newGroup.Add(task);
                    }
                    Console.WriteLine("\nEXPANDED\n");
                }
                else
                {
                    Console.WriteLine("\nNOT EXPANDED\n");    
                }
                ExpandedGroups.Add(newGroup);
            }

            OnPropertyChanged("ExpandedGroups");
            ProjectsListHeight = tasks * 90 + projects * 70 + 10;
        }

        public TodayTasksVM()
        {
            GroupClicked = new RelayCommand<Project>(GroupClickedMethod);

            _allGroups = new List<Project> {
                new Project ("Alfa", "A", "#4dd08a", "Alfa projekt hlavního alfáka") {
                new ToDoTask("Asr", "Spruce sauce", new DateTime(2018,5,29), new DateTime(2018,5,29), 5, "#b6ffb4", false, true),
                new ToDoTask("Amel alir", "Pine apple", new DateTime(2018,7,8), new DateTime(2018,7,8), 4, "#b3ffed", true, true),
                new ToDoTask("Amand", "Maple cake", new DateTime(2018,6,1), new DateTime(2018,6,1), 2, "#fff7b5", true, true)
                },
                new Project ("Bravo", "B", "#68cdbf", "Bingo brácho, budeš brát bravíčko.") {
                new ToDoTask("Bilk", "Yaa sauce", new DateTime(2018,5,29), new DateTime(2018,5,29), 5, "#b6ffb4", true, true),
                new ToDoTask("Balon", "Pine apple", new DateTime(2018,7,8), new DateTime(2018,7,8), 4, "#b3ffed", false, true),
                new ToDoTask("Bark", "Sik cake", new DateTime(2018,6,1), new DateTime(2018,6,1), 2, "#fff7b5", true, true)
                }
            };

            UntagedTasksList = new List<ToDoTask> {
                new ToDoTask("Celer", "Spruce sauce", new DateTime(2018,5,29), new DateTime(2018,5,29), 5, "#b6ffb4", false, false),
                new ToDoTask("Cicka", "Pine apple", new DateTime(2018,7,8), new DateTime(2018,7,8), 4, "#b3ffed", false, false),
                new ToDoTask("Capr", "Maple cake", new DateTime(2018,6,1), new DateTime(2018,6,1), 2, "#fff7b5", true, false)
            };

            TaskListHeight = UntagedTasksList.Count * 90;
            UpdateListContent();
        }
    }
}
