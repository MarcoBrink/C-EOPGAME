

using Microsoft.Xna.Framework;
using System;

namespace C____RPG
{
    public class MainMission : Mission
    {
        private int levelRequired { get; }
        private MainMission nextMission { get; } 


        public MainMission(String name, String description, int reward, int levelRequired, MainMission nextMission, Mode mode) : base(name,description,reward, mode)
        {
            this.levelRequired = levelRequired;
            this.nextMission = nextMission;       
        }
    }
}