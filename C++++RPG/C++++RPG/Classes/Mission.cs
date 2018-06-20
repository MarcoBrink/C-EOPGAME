

using Microsoft.Xna.Framework;
using System;

namespace C____RPG
{
    public abstract class Mission
    {

        private bool finished;
        private bool started { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int reward { get; set; }


        public Mission(String name, String description, int reward)
        {
            this.name = name;
            this.description = description;
            this.reward = reward;
            this.started = false;
        }

        public bool SetFinished()
        {
            if (finished = false)
            {
                finished = true;
                return true;
            }
            else {
                return false; 
            }
        }

        public bool StartMission()
        {
            if (started == false)
            {
                started = true;
                return true;
            }
            else {
                return false;
            }
        }

        public bool IsFinished()
        {
            return finished;
        }

        public MainMission GetNextMission()
        {
            return null;
        }

    }
}