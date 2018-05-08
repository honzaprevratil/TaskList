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
    public partial class AddTask : ContentPage
    {
        public AddTaskVM AddTaskVM = new AddTaskVM();

        public AddTask()
        {
            InitializeComponent();
            this.BindingContext = AddTaskVM;
        }
    }
}