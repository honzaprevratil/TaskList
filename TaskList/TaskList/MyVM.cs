using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TaskList
{
    public class MyVM : INotifyPropertyChanged
    {
        /*private int _exampleXD;
        public int ExampleXD
        {
            get => _exampleXD;
            set
            {
                _exampleXD = value;
                OnPropertyChanged("ExampleXD");
            }
        }*/

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
