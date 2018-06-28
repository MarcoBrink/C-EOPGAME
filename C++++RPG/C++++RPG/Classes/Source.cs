using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;

namespace C____RPG
{
    public class Source
    {

        public string Name { get; }
        public int Experience { get; }
        public Location Location { get; set; }
        public Item resource { get; set; }


        public Source(string name, Item resource, int experience , int x, int y)
        {
            Name = name;
            //Location = new Location(x,y);
            this.resource = resource;
            Experience = experience;
            
        }

    }
}