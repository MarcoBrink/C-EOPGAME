using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace C____RPG
{
    public class Player : Game
    {
        public string name { get; set; }
        private int coins { get; set; }
        private int playtime;
        private int sprite;
        private int design;
        private Inventory inventory;
		private List<Skill> skills;
        private Skill currentSkill;
        //private Location location;
        //private Story missions;

        public Player(string name, int design)
        {
            this.name = name;
            this.design = design;
            playtime = 0;

            skills = new List<Skill>();
            skills.Add(new Skill("fishing"));
            skills.Add(new Skill("mining"));
            skills.Add(new Skill("woodcutting"));
        }

        public int Act(int basexp, Item resource)
        {
            int xp = 0;
            if(currentSkill != null)
            {
                List<Item> tools = inventory.GetTools();

                // Loop through the tools and check for the best one to use
                double bestmultiplier = 1;
                foreach (Item item in tools)
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

        public int ChangeCoins(int amount)
        {
            // Increase or decrease the amount of coins depending on the parameter
            coins = coins + amount;
            return coins;
        }

        public Dictionary<String, dynamic> GetStats()
        {
            // Create a new dictionary to put all the stats in
            // name, coins, playtime, xp and lvl for each skill
            Dictionary<String, dynamic> dictionary = new Dictionary<String, dynamic>();
            dictionary.Add("name", name);
            dictionary.Add("coins", coins);
            dictionary.Add("playtime", playtime);

            // Add all the xp and levels to the dictionary
            foreach(Skill skill in skills)
            {
                dictionary.Add(skill.GetName() + "xp", skill.GetXP()); // "mining" + "xp", 312312312
                dictionary.Add(skill.GetName() + "lvl", skill.GetLevel()); // "fishing" + "lvl", 12
            }            

            return dictionary;
        }

        public int GetSprite()
        {
            return sprite;
        }


    }
}