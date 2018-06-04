//using System;
//using System.Xml.Serialization;
//using System.IO;
//using System.Globalization;
//using Microsoft.Xna.Framework;

//namespace C____RPG
//{
//    // This class handles the save files, creating them, overwriting them and deleting them.
//    // source: https://docs.microsoft.com/en-us/previous-versions/windows/xna/bb203924(v=xnagamestudio.41)
//    public class Save : Game
//    {
//        private string filename;
//        private StorageContainer container;
//        private Stream stream;

//        /*
//            //example data to save
//            public struct SaveGameData
//            {
//                public string PlayerName;
//                public Vector2 AvatarPosition;
//                public int Level;
//                public int Score;
//            }
//        */

//        // Create a save.
//        public Save()
//        {
//            filename = "savegame.sav";
//            SaveGame(serializableObject, filename);

//        }

//        public void SaveGame(T serializableObject, string fileName)
//        {
//            //delete save if it already exists
//            DeleteSave(filename);

//            OpenStorageContainer();

//            // Create the file.
//            stream = container.CreateFile(filename);

//            // Convert the object to XML data and put it in the stream.
//            XmlSerializer serializer = new XmlSerializer(typeof(serializableObject));

//            serializer.Serialize(stream, data);

//            CloseStorageContainer();

//        }

//        public Type LoadSave(String fileName)
//        {
//            OpenStorageContainer();

//            // Check to see whether the save exists.
//            if (!container.FileExists(filename))
//            {
//                // If not, dispose of the container and return.
//                container.Dispose();
//                return;
//            }

//            // Open the file.
//            stream = container.OpenFile(filename, FileMode.Open);

//            XmlSerializer serializer = new XmlSerializer(typeof(serializableObject));

//            serializableObject data = (serializableObject)serializer.Deserialize(stream);

//            CloseStorageContainer();
//        }


//        public void DeleteSave(String fileName)
//        {
//            OpenStorageContainer();

//            //checks wheter the file exists
//            if (container.FileExists(filename))
//            {
//                container.DeleteFile(filename);
//            }

//            CloseStorageContainer();
//        }

//        public void OpenStorageContainer()
//        {
//            // Open a storage container.
//            IAsyncResult result = device.BeginOpenContainer("StorageDemo", null, null);

//            // Wait for the WaitHandle to become signaled.
//            result.AsyncWaitHandle.WaitOne();

//            container = device.EndOpenContainer(result);

//            // Close the wait handle.
//            result.AsyncWaitHandle.Close();
//        }

//        public void CloseStorageContainer()
//        {
//            // Close the file.
//            stream.Close();

//            // Dispose the container, to commit changes.
//            container.Dispose();
//        }
//    }
//}