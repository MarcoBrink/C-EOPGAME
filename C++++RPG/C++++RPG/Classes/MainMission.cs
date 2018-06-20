

using Microsoft.Xna.Framework;
using System;

namespace C____RPG
{
    public class MainMission : Mission
    {
        public int levelRequired { get; }
        public Mission nextMission { get; }



        public MainMission(String name, String description, int reward, int levelRequired, Mission nextMission) : base(name, description, reward)
        {
            this.levelRequired = levelRequired;
            this.nextMission = nextMission;
        }
            
    }
}