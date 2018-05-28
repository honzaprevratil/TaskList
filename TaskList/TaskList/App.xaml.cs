using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskList.DB;
using Xamarin.Forms;

namespace TaskList
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
			MainPage = new TaskList.MainPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
            // Handle when your app resumes
        }
        private static TaskDatabase _database;
        public static TaskDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new TaskDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("TaskListDB.db3"));
                }
                return _database;
            }
        }
    }
}
