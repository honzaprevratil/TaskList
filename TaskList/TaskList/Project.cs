using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace TaskList
{
    public class Project : ObservableCollection<ToDoTask>, INotifyPropertyChanged
    {
        private bool _expanded;

        new public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }
        public string ShortName { get; set; } //will be used for jump lists
        public string Description { get; set; }
        public string HexColor { get; set; }
        public bool Done { get; set; }

        public string TitleWithItemCount
        {
            get
            {
                return string.Format("{0} ({1})", Name, this.Items.Count);
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
                    OnPropertyChanged("Expanded");
                }
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public Project(string name, string shortName, string hexColor)
        {
            Name = name;
            ShortName = shortName;
            HexColor = hexColor;
        }
    }
}
