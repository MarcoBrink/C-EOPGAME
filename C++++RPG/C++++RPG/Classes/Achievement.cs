using Microsoft.Xna.Framework;

namespace C____RPG
{
    // The achievements you can achieve during the game. 
    // They are either achieved or achievable.
    public class Achievement : Game
    {
        private string name;
        private string description;
        private bool achieved;

        // Create a new achievement that has not been achieved yet.
        public Achievement(string name, string description)
        {
            this.name = name;
            this.description = description;
            achieved = false;
        }

        // Get the name of the achievement.
        public string GetName()
        {
            return name;
        }
        
        // Get a description of the achievement
        public string GetDescription()
        
            return description;
        }

        // Check wheter the achievement has been achieved
        public bool IsAchieved()
        {
            return achieved;
        }

        // When the achievement has been achieved, achieved will be set to true.
        public void Achieve()
        {
            achieved = true;
        }
    }
}