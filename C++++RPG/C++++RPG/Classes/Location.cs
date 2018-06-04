using Microsoft.Xna.Framework;
using System;

namespace C____RPG
{
    // locations in the game are made via this location class
    public class Location : Game
    {
        private int x;
        private int y;
        private Tuple<int,int> position;

        // Create a new location by using x and y positions.
        public Location(int x, int y)
        {
            this.x = x;
            this.y = y;
            position = Tuple.Create<int, int>(x,y);
        }

        //Get the location as a tuple of x and y
        public Tuple<int,int> GetPosition()
        {
            return position;
        }

        //get the x position
        public int GetX()
        {
            return position.Item1;
        }

        //get the y position
        public int GetY()
        {
            return position.Item2;
        }
    }
}