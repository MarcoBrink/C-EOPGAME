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
            // Check if item is in the items dictionary
            if(items.ContainsKey(item))
            {
                // Add 1 to the amount
                items[item]++;
            }
            else
            {
                // Add a new item and set the amount to 1
                items.Add(item, 1);
            }
        }

        public bool DiscardItem(Item item, int amount)
        {
            // Check if the item is in the dictionary
            if (items.ContainsKey(item))
            {
                // Check if the amount to discard is in inventory
                if (items[item] >= amount)
                {
                    items[item] = items[item] - amount;
                    return true;
                }                
            }
            return false;
        }

        public List<Item> GetTools()
        {
            // Loop through all the items in inventory
            List<Item> itemList = new List<Item>();
            foreach(Item item in items.Keys)
            {
                // Check if the item is a tool, add tools to the list
                if(item is Tool)
                {
                    itemList.Add(item);
                }
            }
            return itemList;
        }

        public Dictionary<String, dynamic> GetResourceAmount()
        {
            Dictionary<String, dynamic> resources = new Dictionary<String, dynamic>();
            // Loop through all items in inventory
            foreach (Item item in items.Keys)
            {
                // Check if item is a resource, add resources to dictionary
                if (item is Resource)
                {
                    resources.Add(item.GetName(), items[item]);    // "logs", 60
                }
            }

            return resources;
        }
    }
}