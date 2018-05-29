using Microsoft.Xna.Framework;
using System;

namespace C____RPG
{
    public class Shop : Game
    {
        private String name;
        private List<Item> items;
        private Location location;



        public Shop()
        {
            
        }
        
        public List<Item> GetItems()
        {
            return items;
        }

        public Location GetLocation()
        {
            return location;
        }




    }
}