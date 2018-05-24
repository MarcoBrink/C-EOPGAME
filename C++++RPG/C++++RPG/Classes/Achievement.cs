namespace C____RPG
{
    public class Achievement : Game
    {
        private string name;
        private string description;
        private bool achieved;

        public Achievement(string name, string description)
        {
            this.name = name;
            this.description = description;
            achieved = false;
        }

        public int GetName()
        {

            return name;
        }

        public int GetDescription()
        {

            return description;
        }

        public bool IsAchieved()
        {
            return achieved;
        }

        public void Achieve()
        {
            achieved = true;
        }
    }
}