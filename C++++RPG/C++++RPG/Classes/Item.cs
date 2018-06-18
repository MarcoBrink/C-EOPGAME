

using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;

namespace C____RPG
{
    public abstract class Item
    {
        public string name { get; set; }
        public string description { get; set; }
        public int value { get; set; }
        


        public Item(string name, string description, int value)
        {
            this.name = name;
            this.description = description;
            this.value = value;
            
        } 
    }
}