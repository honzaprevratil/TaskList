using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskList.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TodayTasks : ContentPage
	{
        public TodayTasksVM TodayTasksVM = new TodayTasksVM();
        bool navigationSwitch = true;

        public TodayTasks ()
		{
			InitializeComponent ();
            this.BindingContext = TodayTasksVM;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            navigationSwitch = true;
            TodayTasksVM.GetDataFromDb();
        }
        async void TaskClicked(object sender, SelectedItemChangedEventArgs e)
        {
            if (navigationSwitch)
            {
                navigationSwitch = false;
                await Navigation.PushModalAsync(new TaskDetail
                {
                    BindingContext = TodayTasksVM.TasksVM.SelectedTask
                });
            }
        }
        async void ProjectTaskClicked(object sender, SelectedItemChangedEventArgs e)
        {
            if (navigationSwitch)
            {
                navigationSwitch = false;
                await Navigation.PushModalAsync(new TaskDetail
                {
                    BindingContext = TodayTasksVM.ProjectsVM.SelectedTask
                });
            }
        }
    }
}