

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
        private bool started { get; set; }
        public enum Mode { easy, normal, hard };
        private Mode mode;
        

        public Mission(String name, String description, int reward, Mode mode)
        {
            this.name = name;
            this.description = description;
            this.mode = mode;
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