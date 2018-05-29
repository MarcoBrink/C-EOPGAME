using Microsoft.Xna.Framework;
using System;

namespace C____RPG
{
    public class Source : Item
    {

        private String Name { get; }
        public int Experience { get; }
        public Location Location { get; set; }
        private Resource resource;


        public Source(Resource resource, int experience , int x, int y)
        {
            Location = new Location(x,y);
            this.resource = resource;
            Experience = experience;
        }

    }
}