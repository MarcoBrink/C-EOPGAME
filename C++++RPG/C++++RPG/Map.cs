using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C____RPG
{
    class Map
    {
        private List<CollisionTiles> ct = new List<CollisionTiles>();

        public List<CollisionTiles> Ct
        {
            get { return ct; }
        }

        private int width, height;
        public int Width
        {
            get { return width; }
        }
        public int Height
        {
            get { return height; }
        }

        public Map() { }

        public void Generate(double[,] map, int size)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    double number = map[y, x];

                    if (number > 0)
                    {
                        ct.Add(new CollisionTiles(
                            number,
                            new Rectangle(x * size, y * size, size, size)
                        ));
                    }

                    width = (x + 1) * size;
                    height = (y + 1) * size;
                }
            }
        }

        public void Draw(SpriteBatch sb) {
            foreach (CollisionTiles tile in ct)
                tile.Draw(sb);
        }
    }
}
