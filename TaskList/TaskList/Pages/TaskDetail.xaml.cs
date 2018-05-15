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
        public TaskDetail()
        {
            InitializeComponent();
        }
        async void GoBackClick(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        async void EditTaskClick(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddTask
            {
                BindingContext = this.BindingContext
            });
        }
    }
}