namespace C____RPG
{
    public class Player : Game
    {
        private string name;
        private int coins;
        private int playtime;
        private Inventory inventory;
		private dictionary<Skill> skills;
        private Skill currentSkill;
        private Location location;
        private Story missions;

        public Player(string name)
        {
            this.name = name;
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

        public dictionary<String, dynamic> GetStats()
        {
            int coins = clock.GetHours();
            int minutes = clock.GetMinutes();

            Dictionary<String, dynamic> dictionary = new Dictionary<String, dynamic>();
            dictionary.Add("coins", coins);
            dictionary.Add("playtime", playtime);
            //dictionary.Add("miningxp", skills.);
            dictionary.Add("woodcuttingxp", playtime);
            dictionary.Add("fishingxp", playtime);

            return dictionary;
        }




    }
}