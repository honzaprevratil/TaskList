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
        public bool onlyTodayTasks = false;
        
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
            {
                if (LastOpened.Count > 0)
                {
                    List<Project> newLastOpened = LastOpened.Except(LastOpened.Where(x => x.ProjectId == project.ProjectId).ToList()).ToList();
                    LastOpened = newLastOpened;
                }
            }
                
            UpdateListContent();
        }

        public void UpdateListContent()
        {
            ExpandedGroups = new ObservableCollection<Project>();

            int tasks = 0;
            int notExpandedProjects = 0;
            int expandedProjects = 0;

            foreach (Project group in _allGroups)
            {
                Project newGroup = new Project(group.Name, group.ShortName, group.HexColor, group.Description, group.ProjectId)
                {
                    Expanded = group.Expanded
                };

                //int consoleTest = LastOpened.Where(x => x.ProjectId == group.ProjectId).ToList().Count;
                //Console.WriteLine(group.Name + " :: "+ consoleTest);

                List<Project> lastProj = LastOpened.Where(x => x.ProjectId == group.ProjectId).ToList();

                if (group.Expanded || lastProj.Count > 0)
                {
                    newGroup.Expanded = true;
                    group.Expanded = true;
                    tasks += group.Count;
                    foreach (ToDoTask task in group)
                    {
                        newGroup.Add(task);
                    }
                    Console.WriteLine("\nEXPANDED\n");
                    expandedProjects++;
                    if (lastProj.Count > 0)
                    {
                        List<Project> newLastOpened = LastOpened.Except(lastProj).ToList();
                        newLastOpened.Add(newGroup);
                        LastOpened = newLastOpened;
                    }
                }
                else
                {
                    Console.WriteLine("\nNOT EXPANDED\n");
                    notExpandedProjects++;
                }
                ExpandedGroups.Add(newGroup);
            }

            OnPropertyChanged("ExpandedGroups");
            if (onlyTodayTasks)
                ProjectsListHeight = tasks * 90 + (notExpandedProjects + expandedProjects) * 65 + 6;
            else
                ProjectsListHeight = tasks * 90 + notExpandedProjects * 105 + expandedProjects * 135 + 74;

            if (expandedProjects > 0)
                OpenedProject = true;
            else
                OpenedProject = false;
        }
        
        public ProjectsVM()
        {
            GroupClicked = new RelayCommand<Project>(GroupClickedMethod);
            GetDataFromDb();
            UpdateListContent();
        }

        public void GetDataFromDb()
        {
            List<ToDoProject> toDoProjectList = new List<ToDoProject>();
            App.Database.GetItemsAsync<ToDoProject>().Result.ForEach(x => toDoProjectList.Add(x));

            List<ToDoTask> allToDoTasks = new List<ToDoTask>();

            if (onlyTodayTasks)
            {
                App.Database.GetItemsAsync<ToDoTask>().Result
                    .Where(x => DateTime.Compare(x.StartDate, DateTime.Now) <= 0 && !x.Done).ToList()
                    .ForEach(x => allToDoTasks.Add(x));
            }
            else
                App.Database.GetItemsAsync<ToDoTask>().Result.ForEach(x => allToDoTasks.Add(x));


            _allGroups = new List<Project>();// expandable list
            foreach (ToDoProject todoProject in toDoProjectList)
            {
                Project newProject = new Project(todoProject.Name, todoProject.Name[0].ToString(), todoProject.HexColor, todoProject.Description, todoProject.ID);
                allToDoTasks
                    .Where(x => x.ProjectId == newProject.ProjectId).ToList()
                    .ForEach(x => newProject.Add(x));

                if (onlyTodayTasks)
                {
                    if (newProject.Count > 0)
                    {
                        _allGroups.Add(newProject);
                    }
                }
                else
                    _allGroups.Add(newProject);
            }
        }
    }
}
