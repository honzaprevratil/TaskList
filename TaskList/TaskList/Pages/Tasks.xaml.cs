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
    public partial class Tasks : ContentPage
    {
        public TasksVM TasksVM = new TasksVM();
        bool navigationSwitch = true;

        public Tasks()
        {
            InitializeComponent();
            this.BindingContext = TasksVM;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            navigationSwitch = true;
            TasksVM.GetDataFromDb();
        }
        async void AddTaskClick(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddTask(new ToDoTask() { EstimatedTime = 1 }));
        }
        async void TaskClicked(object sender, SelectedItemChangedEventArgs e)
        {
            if (navigationSwitch)
            {
                navigationSwitch = false;
                await Navigation.PushModalAsync(new TaskDetail
                {
                    BindingContext = TasksVM.SelectedTask
                });
            }
        }
    }
}