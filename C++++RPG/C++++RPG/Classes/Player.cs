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
        //private Inventory inventory;
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

        public void Act(int basexp, String skillname)
        {
            // Alles wat gedaan moet worden
            foreach (Skill skill in skills)
            {
                if(skill.Name == skillname)
                {
                    currentSkill = skill;
                }
                else
                {
                    currentSkill = null;
                }
            }

            if(currentSkill == null)
            {
                // idle
            }
            else
            {
                
                List<Item> tools = inventory.GetTools();

                
                    foreach (Item item in tools)
                    {
                        if(item.Skillname == "woodcutting")
                        {
                            currentSkill item.modifier * source.Experience
                        }
                    }
               
                currentSkill.IncreaseXP();
            }
        }

        public int ChangeCoins(int amount)
        {
            coins = coins + amount;
            return coins;
        }

        public Dictionary<String, dynamic> GetStats()
        {
            Dictionary<String, dynamic> dictionary = new Dictionary<String, dynamic>();
            dictionary.Add("coins", coins);
            dictionary.Add("playtime", playtime);

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