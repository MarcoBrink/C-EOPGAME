
using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;

namespace C____RPG
{
   

    public class DailyMission : Mission
    {
        private int streak { get; set; }
        private int ratio { get; set; }      
        private DateTime timeStarted { get; }
        private double timeLeft
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

        public bool SetFinished()
        {
            if ((DateTime.Now - timeStarted).TotalDays < 1)
            {
                //base.SetFinished();
                Debug.WriteLine("Mission Started");
                return true;
                

            }
            else
            {
                //The daily mission has expired 
                Debug.WriteLine("Mission Expired");
                return false;
            }
        }
    }
}