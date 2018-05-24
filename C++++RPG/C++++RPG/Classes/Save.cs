using System;
using System.Globalization;
using Microsoft.Xna.Framework;

namespace C____RPG
{
    //
    public class Save : Game
    {
        private long  lastSave;

        // Create a save.
        public Save()
        {
            lastSave = CalcLastSave();
            //create save file?
        }

        // Calculates the time in miliseconds since Epoch
        private long CalcLastSave()
        {
            DateTime baseDate = new DateTime(1970, 1, 1);
            TimeSpan diff = DateTime.Now - baseDate;
            return diff.TotalMilliseconds;
        }

        // Get the last save time in miliseconds since Epoch
        public long GetLastSave()
        {
            return lastSave;
        }
    }
}