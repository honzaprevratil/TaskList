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
    public class ProjectsVM : MyVM
    {
        private List<Project> _allGroups { set; get; }
        public ObservableCollection<Project> ExpandedGroups { set; get; }
        
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

        private bool _OpenedProject;
        public bool OpenedProject
        {
            get => _OpenedProject;
            set
            {
                _OpenedProject = value;
                OnPropertyChanged("OpenedProject");
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
        private List<Project> _lastOpened = new List<Project>();
        public List<Project> LastOpened
        {
            get => _lastOpened;
            set
            {
                _lastOpened = value;
            }
        }
        // Command with parameter
        public RelayCommand<Project> GroupClicked { get; }
        
        private void GroupClickedMethod(Project project)
        {
            int selectedIndex = ExpandedGroups.IndexOf(project);

            _allGroups[selectedIndex].Expanded = !(_allGroups[selectedIndex].Expanded);

            if (_allGroups[selectedIndex].Expanded)
                LastOpened.Add(_allGroups[selectedIndex]);
            else
                if (LastOpened.Count > 0)
                    LastOpened.RemoveAt(LastOpened.Count-1);

            UpdateListContent();
        }

        public void UpdateListContent()
        {
            ExpandedGroups = new ObservableCollection<Project>();

            int tasks = 0;
            int projects = 0;
            int expandedProjects = 0;

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
                    expandedProjects++;
                }
                else
                {
                    Console.WriteLine("\nNOT EXPANDED\n");    
                }
                ExpandedGroups.Add(newGroup);
            }

            OnPropertyChanged("ExpandedGroups");
            ProjectsListHeight = tasks * 90 + projects * 160 + 90;

            if (expandedProjects > 0)
                OpenedProject = true;
            else
                OpenedProject = false;
        }
        
        public ProjectsVM()
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

            GetDataFromDb();
            UpdateListContent();
        }

        public void GetDataFromDb()
        {
            List<ToDoProject> toDoProjectList = new List<ToDoProject>();
            App.Database.GetItemsAsync<ToDoProject>().Result.ForEach(x => toDoProjectList.Add(x));

            List<ToDoTask> allTasks = new List<ToDoTask>();
            App.Database.GetItemsAsync<ToDoTask>().Result.ForEach(x => allTasks.Add(x));

            DebugUntagedTasksList(toDoProjectList);

            _allGroups = new List<Project>();// expandable list
            foreach (ToDoProject todoProject in toDoProjectList)
            {
                Project newProject = new Project(todoProject.Name, todoProject.Name[0].ToString(), todoProject.HexColor, todoProject.Description, todoProject.ID);
                allTasks
                    .Where(x => x.ProjectId == newProject.ProjectId).ToList()
                    .ForEach(x => newProject.Add(x));
                _allGroups.Add(newProject);
            }

            ProjectsListHeight = toDoProjectList.Count * 160 + 90;
            //OnPropertyChanged("UntagedTasksList");
        }
        public void DebugUntagedTasksList(List<ToDoProject> toDoProjectList)
        {
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");

            Debug.WriteLine(toDoProjectList.Count);
            foreach (ToDoProject todoItem in toDoProjectList)
            {
                Debug.WriteLine(todoItem);
            }

            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");
        }
    }
}
