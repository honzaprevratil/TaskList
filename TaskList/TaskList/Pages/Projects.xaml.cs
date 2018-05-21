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
	public partial class Projects : ContentPage
	{
        public ProjectsVM ProjectsVM = new ProjectsVM();

        public Projects()
        {
            InitializeComponent();
            this.BindingContext = ProjectsVM;
        }
        async void AddProjectClick(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddProject
            {
                //BindingContext = new Project()
            });
        }
        async void TaskClicked(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushModalAsync(new TaskDetail
            {
                BindingContext = ProjectsVM.SelectedTask
            });
        }
        async void EditProjectClick(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddProject
            {
                BindingContext = ProjectsVM.LastOpened[ProjectsVM.LastOpened.Count-1]
            });
        }
    }
}