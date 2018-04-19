using System;
using System.Collections.Generic;
using System.Text;

namespace TaskList
{
    public class Project : List<ToDoTask>
    {
        public string Name { get; set; }
        public string ShortName { get; set; } //will be used for jump lists
        public string Description { get; set; }
        public string HexColor { get; set; }
        public bool Done { get; set; }

        private Project(string name, string shortName, string hexColor)
        {
            Name = name;
            ShortName = shortName;
            HexColor = hexColor;
        }

        public static IList<Project> All { private set; get; }

        static Project()
        {
            List<Project> Groups = new List<Project> {
                new Project ("Alfa", "A", "#4dd08a") {
                    new ToDoTask("Amelia", "Cedar cheese", "#3ec2f4", true, new DateTime(2018,4,25)),
                    new ToDoTask("Alfie", "Spruce sauce", "#3ec2f4", false, new DateTime(2018,5,29)),
                    new ToDoTask("Ava", "Pine apple", "#3ec2f4", false, new DateTime(2018,7,8)),
                    new ToDoTask("Archie", "Maple cake", "#3ec2f4", true, new DateTime(2018,6,1))
                },
                new Project ("Bravo", "B", "#68cdbf"){
                    new ToDoTask("Brooke", "Lumia phone", "#3ec2f4", false, new DateTime(2018,8,1)),
                    new ToDoTask("Bobby", "Xperia X7", "#3ec2f4", false, new DateTime(2018,9,8)),
                    new ToDoTask("Bella", "Desire Aspire", "#3ec2f4", false, new DateTime(2018,9,20)),
                    new ToDoTask("Ben", "Chocolate bars", "#3ec2f4", true, new DateTime(2018,8,5))
                }
            };
            All = Groups; //set the publicly accessible list
        }
    }
}
