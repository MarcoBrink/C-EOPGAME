using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace C____RPG
{
    public class Player : Game
    {
        private string name;
        private int coins;
        private int playtime;
        private int design;
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

        public void Act()
        {
            // Alles wat gedaan moet worden
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

        public int GetDesign()
        {
            return design;
        }


    }
}