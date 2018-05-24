/*  
    @author Marco Brink
    @date   24-05-2018
 
*/

using Microsoft.Xna.Framework;
using System;

namespace C____RPG
{
    public abstract class Item : Game
    {
        private string name;
        private string description;
        private int value;


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

        public string GetDescription() 
        {
            return description;
        }

        public void SetValue(int newValue) 
        {
            value = newValue;
        }

        public abstract int GetValue();
       


       




    }
}