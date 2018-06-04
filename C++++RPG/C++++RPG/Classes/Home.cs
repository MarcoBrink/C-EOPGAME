using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;

namespace C____RPG
{
    public class Home
    {
        public String Name { get; set; }
        public int Rent { get; set; }
        public int tier { get; set; }
        public Location Location { get; set; }


        public Home(string name, int x, int y)
        {
            this.Name = name;
            Rent = 500;
            tier = 1;
            Location = new Location(x, y);
            
        }

        public void Upgrade()
        {
            tier += 1;
        }
        
    }
}