namespace C____RPG
{
    public class Player : Game
    {
        private string name;
        private int experience;
        private int currentLevel;

        public Skill(string name)
        {
            this.name = name;
            currentLevel = 0;
        }

        public int GetXP()
        {
            return experience;
        }

        public void IncreaseXP(int amount)
        {
            experience += amount;
            int curlvl = (int)(0.1f * Mathf.Sqrt(experience));

            if (curlvl != currentLevel)
            {
                //Level up!
                currentLevel = curlvl;
            }

            //The total XP that is needed to reach the next level 
            int totalXpNextlevel = 100 * (currentlevel + 1) + (currentlevel + 1)

           //The difference between your current experience and the xp needed to reach the next level.
            int difference = xpnextlevel - experience;

            //The total experience difference between your current level and the next level
            int totalLevelDifference

        }

        public int GetLevel()
        {

            return level;
        }




    }
}