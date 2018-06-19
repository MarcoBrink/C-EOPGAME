using System.Xml.Serialization;
using System.IO;
using Microsoft.Xna.Framework;


namespace C____RPG
{
    // This class handles the save files, creating them, overwriting them and deleting them.
    // source: https://docs.microsoft.com/en-us/previous-versions/windows/xna/bb203924(v=xnagamestudio.41)
    public class Save : Game
    {
        
  
    // Create a save.
        public Save(string Name)
        {
            Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            //localSettings.Values["Name"] = Name;
        }

    }
}