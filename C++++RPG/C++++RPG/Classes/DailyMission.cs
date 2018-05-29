
using Microsoft.Xna.Framework;
using System;

namespace C____RPG
{
   

    public class DailyMission : Mission
    {
        private int streak { get; set; }
        private int ratio { get; set; }      
        private DateTime timeStarted { get; }
        private DateTime timeLeft
        {
            get
            {
               return (DateTime.Now - timeStarted).TotalMinutes;
            }
        }

        public DailyMission(String name, String description, int reward, DateTime timeStarted) : base(name,description,reward)
        {
            this.timeStarted = timeStarted;
        }

        public override bool SetFinished()
        {
            if ((DateTime.Now - timeStarted).TotalDays < 1)
            {
                base.setFinished();
                return true;
                Console.WriteLine("Mission Started");

            }
            else
            {
                //The daily mission has expired 
                return false;
                Console.WriteLine("Mission Expired");
            }
        }
    }
}