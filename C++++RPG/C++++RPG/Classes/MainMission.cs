

using Microsoft.Xna.Framework;
using System;

namespace C____RPG
{
    public class MainMission : Mission
    {
        public int levelRequired { get; }
        public Mission nextMission { get; }
        public int reward { get; set; }
        



        public MainMission(String name, String description, int reward, int levelRequired, Mission nextMission, int toGo, string skill) : base(name, description, reward, toGo, skill)
        {
            this.reward = reward;
            this.levelRequired = levelRequired;
            this.nextMission = nextMission;


        }

 
            
    }
}