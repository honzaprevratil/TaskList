using System;
using System.Collections.Generic;
using System.Text;

namespace TaskList
{
    public class Color
    {
        public string Name { get; set; }
        public string HexColor { get; set; }

        public Color(string name, string hexColor)
        {
            Name = name;
            HexColor = hexColor;
        }
    }
}
