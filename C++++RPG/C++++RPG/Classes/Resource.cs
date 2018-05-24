/*  
    @author Marco Brink
    @date   24-05-2018
 
*/

using Microsoft.Xna.Framework;
using System;

namespace C____RPG
{
    public class Resource : Item
    {
        private string name;
        private string description;
        private int value;


        public Resource(string name, string description, int value)
        {
            this.name = name;
            this.description = description;
            this.value = value;
        }
    }
}