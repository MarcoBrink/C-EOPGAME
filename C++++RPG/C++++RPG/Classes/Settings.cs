using Microsoft.Xna.Framework;

namespace C____RPG
{
    /* 
     *   The settings of the game.
     *   Here you can change various settings of the game.
     */
    public class Settings : Game
    {
        public string language;
        private bool muted;
        private bool notificationOn;
        private bool soundOn;
        private bool quit;

        // Create settings depending on the language.
        public Settings(string language)
        {
            this.language = language;
            muted = false;
            notificationOn = true;
            soundOn = true;
            quit = false;
        }

        // Get the language of the settings.
        public string GetLanguage()
        {
            return language;
        }

        //  Checks wheter the audio is muted or not.
        public bool IsMuted()
        {
            return muted;
        }

        // Checks wheter receiving notifications is on or off.
        public bool IsNotificationOn()
        {
            return notificationOn;
        }

        // Checks wheter the background sound of the game is on or off.
        public bool IsSoundOn()
        {
            return soundOn;
        }

        // Checks wheter to quit the game.
        public bool HasQuit()
        {
            return quit;
        }

        // function that toggles the value of booleans
        private bool ToggleBool(bool boolean)
        {
            boolean = !boolean;
            return boolean;
        }

        // Bunch of methods to toggle their boolean value.

        public void ToggleMute()
        {
            muted = ToggleBool(muted);
        }

        public void ToggleNotification()
        {
            notificationOn = ToggleBool(notificationOn);
        }

        public void ToggleSound()
        {
            soundOn = ToggleBool(soundOn);
        }

        public void ToggleQuit()
        {
            quit = ToggleBool(quit);
        }
    }
}