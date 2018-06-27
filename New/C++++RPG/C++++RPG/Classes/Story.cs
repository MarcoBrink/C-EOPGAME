/*  
    @author Marco Brink
    @date   29-05-2018
 
*/

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace C____RPG
{
    public class Story : Game
    {
        private Dictionary<String, Mission> storyline;
        private Dictionary<String, Mission> dailyMission;
        private Mission currentMission;
        private int progress;


        public Story()
        {

            storyline = new Dictionary<string, Mission>();

           
            MainMission m3 = new MainMission("[Tutorial] Discover ores.", "Get 25 ore, click on the map to navigate", 100, 0, null, 25, "ore");
            MainMission m2 = new MainMission("[Tutorial] Discover food.", "Get 25 fish, click on the map to navigate", 100, 0, m3, 25, "fish");
            MainMission m1 = new MainMission("[Tutorial] Discover Wood.", "Get 25 wood, click on the map to navigate", 100, 0, m2, 25, "wood");

            currentMission = m1;

            storyline.Add("t_wood",m1);
            storyline.Add("t_fish", m2);
            storyline.Add("t_ore", m3);
            



        }

        public DailyMission GetDailyMission()
        {
            return null;
        }

       

        public dynamic GetCurrentMission()
        {
            return currentMission; 
        }

        public bool NextMainMission(MainMission CurrentMission)
        {

            this.currentMission = CurrentMission.nextMission;
                return true;
         
        } 
    }
}