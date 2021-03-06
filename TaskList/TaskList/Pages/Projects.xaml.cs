﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskList.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Projects : ContentPage
	{
        public ProjectsVM ProjectsVM = new ProjectsVM();
        bool navigationSwitch = true;

        public Projects()
        {
            InitializeComponent();
            this.BindingContext = ProjectsVM;
        }
        async void DeleteProjectClick(object sender, EventArgs e)
        {
            int projectId = ProjectsVM.LastOpened[ProjectsVM.LastOpened.Count - 1].ProjectId;
            ToDoProject delete = new ToDoProject() { ID = projectId };
            await App.Database.DeleteItemAsync(delete);
            List<ToDoTask> deleteTasks = App.Database.GetItemsAsync<ToDoTask>().Result.Where(x => x.ProjectId == projectId).ToList();
            deleteTasks.ForEach(x => App.Database.DeleteItemAsync(x));
            ProjectsVM.GetDataFromDb();
            ProjectsVM.UpdateListContent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ProjectsVM.GetDataFromDb();
            ProjectsVM.UpdateListContent();
            navigationSwitch = true;
        }
        async void AddProjectClick(object sender, EventArgs e)
        {
            if (navigationSwitch)
            {
                navigationSwitch = false;
                await Navigation.PushModalAsync(new AddProject(new Project()));
            }
        }
        async void TaskClicked(object sender, SelectedItemChangedEventArgs e)
        {
            if (navigationSwitch)
            {
                navigationSwitch = false;
                await Navigation.PushModalAsync(new TaskDetail
                {
                    BindingContext = ProjectsVM.SelectedTask
                });
            }
        }
        async void EditProjectClick(object sender, EventArgs e)
        {
            if (navigationSwitch)
            {
                navigationSwitch = false;
                await Navigation.PushModalAsync(new AddProject(ProjectsVM.LastOpened[ProjectsVM.LastOpened.Count - 1]));
            }
        }
    }
}