/*  
    @author Marco Brink
    @date   24-05-2018

    

    
*/

using Microsoft.Xna.Framework;
using System;

namespace C____RPG
{
    public class Skill : Game
    {
        private string name;
        private int experience;
        private int currentLevel;
        private int totalXpNextLevel;


        public Skill(string name)
        {
            this.name = name;
            currentLevel = 0;
            totalXpNextLevel = 0;
        }
        
        public int GetXP()
        {
            return experience;
        }

        public void IncreaseXP(int amount) 
        {
           experience += amount;
           int curlvl = (int)(0.1f * Math.Sqrt(experience));

           if (curlvl != currentLevel) 
           {
               //Level up!
               currentLevel = curlvl;
           }

            //The total XP(all the collected XP + the XP from 1 level more) that is needed to reach the next level 
            totalXpNextLevel = 100 * (currentLevel + 1) + (currentLevel + 1);

            //The difference between your current experience and the xp needed to reach the next level.
            int difference = totalXpNextLevel - experience;

            //The total experience difference between your current level and the next level
            int totalLevelDifference = totalXpNextLevel - (100 * currentLevel * currentLevel);

        }
        
        public int GetLevel() 
        {
            int lvl = (int)(0.1f * Math.Sqrt(experience));
            return lvl;
        }

        public string GetName() 
        {
            return name;
        }




    }
}