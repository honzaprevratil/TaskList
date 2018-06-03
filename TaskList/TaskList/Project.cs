using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Linq;


namespace TaskList
{
    public class Project : ObservableCollection<ToDoTask>, INotifyPropertyChanged
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; } //will be used for jump lists
        public string Description { get; set; }
        public string HexColor { get; set; }

        private bool _expanded = false;
        private string _imageSource = "down_arrow.png";

        public string ImageSource
        {
            get { return _imageSource; }
        }

        public string HoursToDo
        {
            get
            {
                int hoursToDo = 0;
                this.Items
                    .Where(x => !x.Done).ToList() // if not done
                    .ForEach(x => hoursToDo += x.EstimatedTime); //add EstimatedTime
                int allHours = 0;
                this.Items.ToList().ForEach(x => allHours += x.EstimatedTime);
                return hoursToDo + " / " + allHours;
            }
        }
        public string TasksToDo
        {
            get
            {
                int undone = this.Items.Where(x => !x.Done).Count(); // if not done
                int all = this.Items.Count();
                return undone + " / " + all;
            }
        }

        public bool Expanded
        {
            get { return _expanded; }
            set
            {
                if (_expanded != value)
                {
                    _expanded = value;
                    OnPropertyChanged("Expanded");
                    
                    if (_expanded)
                        _imageSource = "up_arrow.png";
                    else
                        _imageSource = "down_arrow.png";
                    OnPropertyChanged("ImageSource");
                }
            }
        }

        public Project(string name, string shortName, string hexColor, string description, int projectId = 0)
        {
            ProjectId = projectId;
            Name = name;
            ShortName = shortName;
            HexColor = hexColor;
            Description = description;
        }
        public Project() { }

        new public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
