using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace C____RPG
{
    public class Gamerino
    {
        private Player player;
        private Shop shop;
        private Home home;
        //private Dictionary<String, Audio> sounds;
        private Dictionary<String, Source> sources { get; }
        private List<Item> items;
        private List<Achievement> achievements;
        //private Save save { get; }

        public Gamerino()
        {
            //sounds = new Dictionary<string, Audio>();
            sources = new Dictionary<string, Source>();
            items = new List<Item>();
            achievements = new List<Achievement>();
        }

        public void Update()
        {

        }

        public Dictionary<String, dynamic> GetData()
        {
            return null;
        }

    }
}