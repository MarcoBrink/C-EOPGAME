

using Microsoft.Xna.Framework;
using System;

using System.Diagnostics;

using System.Collections.Generic;


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

        public string GetName()
        {
            return name;
        }

        public Dictionary<String, dynamic> GetItemDetails()
        {
            Dictionary<String, dynamic> itemdetails = new Dictionary<String, dynamic>();
            itemdetails.Add("name", name);
            itemdetails.Add("description", description);
            itemdetails.Add("value", value);

            return itemdetails;
        }

    }
}