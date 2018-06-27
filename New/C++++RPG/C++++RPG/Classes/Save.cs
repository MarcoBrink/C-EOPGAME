using System;
using System.Xml.Serialization;
using System.IO;
using System.Globalization;
using Microsoft.Xna.Framework;


using System.Diagnostics;
using System.IO.IsolatedStorage;

namespace C____RPG
{
    public class Save
    {

        private Player p;

        public Save()
        {

            //p = new Player("daan",1);
            Debug.WriteLine("0");

        }

        IsolatedStorageFile savegameStorage = IsolatedStorageFile.GetUserStoreForApplication();
        public void SaveGame()
        {
            Debug.WriteLine("1");
            IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("high_score.txt", FileMode.OpenOrCreate,
                FileAccess.Write, savegameStorage);
            using (StreamWriter sw = new StreamWriter(isoStream))
            {
                Debug.WriteLine("2");
                sw.Flush();
                sw.WriteLine(p.name);
                Debug.WriteLine("3");
            }
        }
        public void LoadGame()
        {
            if (savegameStorage.FileExists("high_score.txt"))
            {
                IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("high_score.txt", FileMode.OpenOrCreate,
                    FileAccess.Read, savegameStorage);
                using (StreamReader sr = new StreamReader(isoStream))
                {
                    p.name = sr.ReadLine();
                }
            }
            else
            {
                
            }
        }

    }
}