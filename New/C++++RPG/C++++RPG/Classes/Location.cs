using Microsoft.Xna.Framework;
using System;

namespace C____RPG
{
    // locations in the game are made via this location class
    public class Location
    {
        public int x { get; set; }
        public int y { get; set; }

        // Create a new location by using x and y positions.
        public Location(int x, int y)
        {
            this.x = x;
            this.y = y;
            
        }

        
    }
}