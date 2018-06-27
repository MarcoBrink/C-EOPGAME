using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace C____RPG
{
    class Animation
    {
        public String Name { get; }
        private int duration;
        public String Path { get; set; }
        String[] movement;
        List<int[]> moveReturn;
        Dictionary<String, List<int[]>> animations;

        public Animation(String name, String path, params String[] move)
        {
            Name = name;
            Path = path;
            movement = move;
            animations = new Dictionary<string, List<int[]>>();
            makeAnimation("start");

        }

        //gives a list of data that generates a path with name attached to it.
        public List<int[]> getAnimation(String name)
        {
            
            foreach (var anim in animations)
            {
                if (anim.Key == name )
                {
                    return anim.Value;
                }
            }
            return null;
        }

        //add a path to the animation set. could be something like => woodcuttingToMiddelToFishingToMining.
        // this would walk to the middle, than to fishing and at last to mining.
        public void Add_Movement(String name, params String[] move)
        {
            movement = move;
            makeAnimation(name);
            

        }

        //inside function that creates the new animation from the current movereturn set.
        private void makeAnimation(String name)
        {
            moveReturn = new List<int[]>();
            foreach (String mov in movement)
            {
                List<String> xy = mov.Split(',').ToList<String>();
                int x = Int32.Parse(xy[0]);
                int y = Int32.Parse(xy[1]);
                int[] ar = { x, y };
                //Debug.WriteLine(x + "" + y);
                moveReturn.Add(ar);

            }
            animations.Add(name, moveReturn);
        }

    }
}
