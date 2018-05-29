

using Microsoft.Xna.Framework;
using System;

namespace C____RPG
{
    public abstract class Item
    {
        private string name { get; set; }
        private string description { get; set; }
        private int value { get; set; }
        


        public Item(string name, string description, int value)
        {
            this.name = name;
            this.description = description;
            this.value = value;       
        } 
    }
}