using Microsoft.Xna.Framework;
using System;

namespace C____RPG
{
    public class Source
    {

        private String Name { get; }
        public int Experience { get; }
        public Location Location { get; set; }
        private Resource resource;


        public Source(String name, Resource resource, int experience , int x, int y)
        {
            Name = name;
            Location = new Location(x,y);
            this.resource = resource;
            Experience = experience;
        }

    }
}