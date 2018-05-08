using System;
using System.Collections.Generic;
using System.Text;

namespace TaskList.Pages
{
    public class AddTaskVM
    {
        public List<Color> Colors { get; set; }
        public int ColorsListHeight { get; set; }

        public AddTaskVM()
        {
            Colors = new List<Color> {
                new Color("Red","#ffb3b3"),
                new Color("Pink","#ffb3fd"),
                new Color("Purple","#b4b3ff"),
                new Color("Blue","#b3ffed"),
                new Color("Green","#b6ffb4"),
                new Color("Yellow","#fff7b5"),
            };
            ColorsListHeight = Colors.Count * 36 + 2;
        }
    }
}
