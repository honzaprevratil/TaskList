﻿using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace TaskList
{
    public class TodayTasksVM : INotifyPropertyChanged
    {
        private List<Project> _allGroups { set; get; }

        public ObservableCollection<Project> ExpandedGroups { set; get; }
        public List<ToDoTask> UntagedTasksList { get; set; }
        public int TaskListHeight { get; set; }

        private int _numberOfClicks = 1;
        public int NumberOfClicks
        {
            get => _numberOfClicks;
            set
            {
                _numberOfClicks = value;
                OnPropertyChanged("NumberOfClicks");
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
        // Command
        public RelayCommand ClickCommand { get; }

        // Command s parametrem
        public RelayCommand<Project> GroupClicked { get; }

        private void ClickMethod()
        {
            NumberOfClicks++;
        }
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
                Project newGroup = new Project(group.Name, group.ShortName, group.HexColor)
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
            ClickCommand = new RelayCommand(ClickMethod);
            GroupClicked = new RelayCommand<Project>(GroupClickedMethod);
            NumberOfClicks = 0;

            _allGroups = new List<Project> {
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

            UntagedTasksList = new List<ToDoTask> {
                new ToDoTask("Celer", "Spruce sauce", "#b6ffb4", false, new DateTime(2018,5,29)),
                new ToDoTask("Cicka", "Pine apple", "#b3ffed", false, new DateTime(2018,7,8)),
                new ToDoTask("Capr", "Maple cake", "#fff7b5", true, new DateTime(2018,6,1))
            };

            TaskListHeight = UntagedTasksList.Count * 90;
            UpdateListContent();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
