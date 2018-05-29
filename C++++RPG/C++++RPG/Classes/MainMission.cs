

using Microsoft.Xna.Framework;
using System;

namespace C____RPG
{
    public class MainMission : Mission
    {
        private int levelRequired { get; }
        private MainMission nextMission { get; } 


        public MainMission(String name, String description, int reward, int levelRequired, MainMission nextMission) : base(name,description,reward)
        {
            this.levelRequired = levelRequired;
            this.nextMission = nextMission;       
        }
    }
}