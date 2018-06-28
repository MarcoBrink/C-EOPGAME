using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace C____RPG
{
    public class Shop
    {
        private String name;
        private List<Item> items;
        private Location location;


        public Shop()
        {
            items = new List<Item>();
        }
        
        public List<Item> GetItems()
        {
            Debug.WriteLine("SIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII");
            return items;
        }

        public Location GetLocation()
        {
            return location;
        }

        public void AddItem(Item item)
        {
            
            items.Add(item);
        }



    }
}