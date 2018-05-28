using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

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

        new public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
