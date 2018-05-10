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
    public partial class TaskDetail : ContentPage
    {
        public AddTaskVM AddTaskVM = new AddTaskVM();

        public TaskDetail()
        {
            InitializeComponent();
            this.BindingContext = AddTaskVM;
        }
    }
}