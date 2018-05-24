using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MyGame
{
    public static class Graphics : Game
    {
        private int tileSize;
        private int width;
        private int height;
        
        public static void load(ContentManager content)
        {
        }

        public void Graphic(int gTile, int gWidth, int gHeight) {
            tileSize = gTile;
            width = gWidth;
            height = gHeight;
        }
    }
}