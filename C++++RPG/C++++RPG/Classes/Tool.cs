

using Microsoft.Xna.Framework;
using System;

namespace C____RPG
{
    public class Tool : Item
    {
        private int modifier { get; set;}
        private int requiredLevel { get; set;}

        public Tool(string name, string description, int value, int modifier, int requiredLevel) : base(name, description, value)
        {
            this.modifier = modifier;
            this.requiredLevel = requiredLevel;
        }
    }
}