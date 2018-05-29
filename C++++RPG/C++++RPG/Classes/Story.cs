/*  
    @author Marco Brink
    @date   29-05-2018
 
*/

using Microsoft.Xna.Framework;
using System;

namespace C____RPG
{
    public class Story : Game
    {
        private Dictionary<String, MainMission> storyline;
        private Dictionary<String, DailyMission> dailyMission;
        private MainMission currentMission;


        public Story()
        {
            
        }

        public DailyMission GetDailyMission()
        {
            
        }

        public MainMission GetCurrentMission()
        {
            return currentMission; 
        }

        public bool NextMainMission(mainMission CurrentMission)
        {
            if (CurrentMission.IsFinished())
            {
                CurrentMission = CurrentMission.GetNextMission();
                return true;
            }
            else {
                //Current main mission not finished
                return false;
            }
        } 
    }
}