using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace C____RPG
{
    public class Player : Game
    {
        public string name { get; set; }
        public int coins { get; set; }
        private int totalcoinsearned;
        private int totalplaytime;
        private int sessionplaytime;
        private int sprite;
        private int design;
        private Inventory inventory;
        private List<Skill> skills;
        private Skill currentSkill;
        private Location location;
        private Story missions;
        private Stopwatch stopwatch;
        private int level;
        public Home home {get;}

        public Player(string name, int design)
        {
            home = new Home(name , 500, 500);
            this.name = name;
            this.design = design;
            totalplaytime = 0;
            sessionplaytime = 0;
            inventory = new Inventory();
            level = 1;

            location = new Location(868,475);

            skills = new List<Skill>();
            skills.Add(new Skill("fishing"));
            skills.Add(new Skill("mining"));
            skills.Add(new Skill("woodcutting"));

            stopwatch = new Stopwatch();
            stopwatch.Start();
            missions = new Story();
            
            

        }

        public int Act(int basexp, Item resource)
        {
            int xp = 0;
            if(currentSkill != null)
            {
                List<Item> tools = inventory.GetTools();

                // Loop through the tools and check for the best one to use
                double bestmultiplier = 1;
                foreach (Tool item in tools)
                {
                    Dictionary<String, dynamic> itemdetails = item.GetItemDetails();
                    if (itemdetails["skill"] == currentSkill.GetName())
                    {
                        bestmultiplier = itemdetails["multiplier"];
                    }
                }
                // Calculate the experience points and increase it in the skill
                xp = Convert.ToInt32(Math.Round(bestmultiplier * basexp));

                currentSkill.IncreaseXP(xp);
            }

            // Add the item to the inventory
            if(resource != null)
            {
                inventory.AddItem(resource);
            }

            return xp;
        }

        public bool ChangeSkill(string skillname)
        {
            // Loop through the skills and set currentSkill to the right one
            foreach (Skill skill in skills)
            {                
                if(skill.GetName().Equals(skillname))
                {
                    currentSkill = skill;
                    return true;
                }
            }
            return false;
        }

        public int ChangeCoins(int amount, bool plus)
        {
            // Increase or decrease the amount of coins depending on the parameter
            if (plus)
            {
                coins += amount;
            }
            else
            {
                coins -= amount;
            }

            // Add all positive amounts to totalcoinsearned
            if (amount > 0)
            {
                totalcoinsearned = totalcoinsearned + amount;
            }
            return coins;
        }

        

        public Dictionary<String, dynamic> GetStats()
        {
            // Create a new dictionary to put all the stats in
            // name, coins, playtime, xp and lvl for each skill
            Dictionary<String, dynamic> dictionary = new Dictionary<String, dynamic>();
            dictionary.Add("name", name);
            dictionary.Add("coins", coins);
            dictionary.Add("totalearned", totalcoinsearned);

            stopwatch.Stop();
            sessionplaytime = Convert.ToInt32(stopwatch.ElapsedMilliseconds) / 1000;
            stopwatch.Start();

            dictionary.Add("totalplaytime", totalplaytime + sessionplaytime);
            dictionary.Add("sessionplaytime", sessionplaytime);

            // Add all the xp and levels to the dictionary
            var most = 0;
            var mostplayed = "null";
            foreach (Skill skill in skills)
            {
                if (skill.GetXP() > most)
                {
                    most = skill.GetXP();
                    mostplayed = skill.GetName();
                }
                dictionary.Add(skill.GetName() + "xp", skill.GetXP()); // "mining" + "xp", 312312312
                dictionary.Add(skill.GetName() + "lvl", skill.GetLevel()); // "fishing" + "lvl", 12
            }

            dictionary.Add("mostplayedskill", mostplayed);


            return dictionary;
        }


        public int GetSprite()
        {
            return sprite;
        }

        public Location getLocation()
        {
            return location;
        }

        public Story getStory()
        {
            return missions;
        }

        public Inventory GetInventory()
        {
            return inventory;
        }

        public double getHouse()
        {
            if (home.tier == 1)
                return 41;
            else if (home.tier == 2)
                return 46;
            else if (home.tier == 3)
                return 47;
            else if (home.tier == 4)
                return 39;
            else if (home.tier == 5)
                return 48;
            return 0;

        }

        public double getPathing(string side)
        {
            if (home.tier < 4)
                if (side == "LL")
                    return 44;
                else if (side == "RL")
                    return 45;
                else if (side == "up")
                    return 42;
                else if (side == "sideways")
                    return 43;
            return 40;
        }

    }
}