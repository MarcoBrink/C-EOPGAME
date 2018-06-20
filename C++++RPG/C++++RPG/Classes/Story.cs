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


        public Story()
        {

            storyline = new Dictionary<string, Mission>();

            Mission m4 = new MainMission("[Tutorial] Shopping spree", "Buy something in the shop, click on the house to navigate to the shop", 100, 0, null);
            Mission m3 = new MainMission("[Tutorial] Discover ores.", "Get 25 ore, click on the map to navigate", 100, 0, m4);
            Mission m2 = new MainMission("[Tutorial] Discover food.", "Get 25 fish, click on the map to navigate", 100, 0, m3);
            Mission m1 = new MainMission("[Tutorial] Discover Wood.", "Get 25 wood, click on the map to navigate", 100, 0, m2);

            currentMission = m1;

            storyline.Add("t_wood",m1);
            storyline.Add("t_fish", m2);
            storyline.Add("t_ore", m3);
            storyline.Add("t_shop", m4);



        }

        public DailyMission GetDailyMission()
        {
            return null;
        }

        public Mission GetCurrentMission()
        {
            return currentMission; 
        }

        public bool NextMainMission(MainMission CurrentMission)
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