using System;
using System.Collections.Generic;
using System.Text;

namespace TaskList
{
    public class Project : List<Task>
    {
        public string Name { get; set; }
        public string ShortName { get; set; } //will be used for jump lists
        public string Description { get; set; }
        private Project(string name, string shortName)
        {
            Name = name;
            ShortName = shortName;
        }

        public static IList<Project> All { private set; get; }

        static Project()
        {
            List<Project> Groups = new List<Project> {
                new Project ("Alfa", "A") {
                    new Task("Amelia", "Cedar cheese", "#3ec2f4", true),
                    new Task("Alfie", "Spruce sauce", "#3ec2f4", false),
                    new Task("Ava", "Pine apple", "#3ec2f4", false),
                    new Task("Archie", "Maple cake", "#3ec2f4", true)
                },
                new Project ("Bravo", "B"){
                    new Task("Brooke", "Lumia phone", "#3ec2f4", false),
                    new Task("Bobby", "Xperia X7", "#3ec2f4", false),
                    new Task("Bella", "Desire Aspire", "#3ec2f4", false),
                    new Task("Ben", "Chocolate bars", "#3ec2f4", true)
                }
            };
            All = Groups; //set the publicly accessible list
        }
    }
}
