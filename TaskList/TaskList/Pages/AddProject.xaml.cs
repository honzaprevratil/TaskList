using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProject : ContentPage
    {
        public AddProjectVM AddProjectVM = new AddProjectVM();

        public AddProject()
        {
            InitializeComponent();
            this.BindingContext = AddProjectVM;
        }
        public AddProject(ToDoProject project)
        {
            InitializeComponent();
            AddProjectVM.LoadProject(project);
            this.BindingContext = AddProjectVM;
        }
        async void GoBackClick(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        async void SaveProject(object sender, EventArgs e)
        {
            if (AddProjectVM.SaveProjectIfValid())
            {
                await Navigation.PopModalAsync();
            }
        }
    }
}