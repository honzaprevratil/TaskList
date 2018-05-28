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
        bool navigationSwitch = true;

        public TaskDetail()
        {
            InitializeComponent();
        }
        async void GoBackClick(object sender, EventArgs e)
        {
            if (navigationSwitch)
            {
                navigationSwitch = false;
                await Navigation.PopModalAsync();
            }
        }
        async void EditTaskClick(object sender, EventArgs e)
        {
            if (navigationSwitch)
            {
                navigationSwitch = false;
                await Navigation.PushModalAsync(new AddTask((ToDoTask)this.BindingContext));
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            int Id = ((ToDoTask)this.BindingContext).ID;
            this.BindingContext = App.Database.GetItemAsync<ToDoTask>(Id).Result;
            navigationSwitch = true;
        }
        async void DeleteClick(object sender, EventArgs e)
        {
            if (navigationSwitch)
            {
                navigationSwitch = false;
                await App.Database.DeleteItemAsync(((ToDoTask)this.BindingContext));
                await Navigation.PopModalAsync();
            }
        }
        async void UpdateDone(object sender, EventArgs e)
        {
            await App.Database.SaveItemAsync(((ToDoTask)this.BindingContext));
        }
    }
}