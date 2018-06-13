

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace C____RPG
{
    public class Tool : Item
    {
        private string skill;
        private int modifier;
        private int requiredLevel;

        public Tool(string name, string description, int value, string skill, int modifier, int requiredLevel) : base(name, description, value)
        {
            this.skill = skill;
            this.modifier = modifier;
            this.requiredLevel = requiredLevel;
        }

        public new Dictionary<String, dynamic> GetItemDetails()
        {
            Dictionary<String, dynamic> itemdetails = base.GetItemDetails();
            itemdetails.Add("skill", skill);
            itemdetails.Add("modifier", modifier);
            itemdetails.Add("requiredLevel", requiredLevel);

            return itemdetails;
        }
    }
}