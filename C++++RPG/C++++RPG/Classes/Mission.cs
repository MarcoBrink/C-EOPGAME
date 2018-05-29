

using Microsoft.Xna.Framework;
using System;

namespace C____RPG
{
    public abstract class Mission
    {
        private String name;
        private String description;
        private int reward;
        private bool finished;
        private bool started;


        public Mission(String name, String description, int reward)
        {
            this.name = name;
            this.description = description;
            this.mode = mode;
            this.reward = reward;
            this.started = started;
        }

        public abstract bool SetFinished()
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
    }
}