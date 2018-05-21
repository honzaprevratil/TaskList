﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTask : ContentPage
    {
        public AddTaskVM AddTaskVM = new AddTaskVM();

        public AddTask()
        {
            InitializeComponent();
            this.BindingContext = AddTaskVM;
        }
        async void GoBackClick(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        async void SaveTask(object sender, EventArgs e)
        {
            ToDoTask saveMe = AddTaskVM.GetTaskToSave();
            await App.Database.SaveItemAsync(saveMe);
            await Navigation.PopModalAsync();
        }
    }
}