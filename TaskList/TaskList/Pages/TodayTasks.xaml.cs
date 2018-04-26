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

		public TodayTasks ()
		{
			InitializeComponent ();
            this.BindingContext = TodayTasksVM;
        }
	}
}