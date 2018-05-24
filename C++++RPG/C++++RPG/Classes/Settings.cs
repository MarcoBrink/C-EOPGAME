namespace C____RPG
{
    /* 
     *   The settings of the game.
     *   Here you can change various settings of the game.
     */
    public class Settings : Game
    {
        public string language;
        private bool mute;
        private bool notification;
        private bool sound;

        // Create settings depending on the language.
        public Settings(string language)
        {
            this.language = language;
            mute = false;
            notification = true;
            sound = true;
        }

        // Get the language of the settings.
        public string GetLanguage()
        {
            return language;
        }

        //  Checks wheter the audio is muted.
        public int GetMute()
        {

            return mute;
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