using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace C____RPG
{
    public class Inventory : Game
    {
        private Dictionary<Item, int> items;

        public Inventory()
        {
            items = new Dictionary<Item, int>();
        }

        public void AddItem(Item item)
        {
            // Alles wat gedaan moet worden
        }

        public void DiscardItem(Item item, int amount)
        {

        }

        public void GetTools()
        {
            List<Item> itemList = new List<Item>();
            foreach(Item item in items.Keys)
            {
                if(item is Tool)
                {
                    itemList.Add(item);
                }
            }
            return itemList;
        }
    }
}