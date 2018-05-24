using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using MonoGame.Extended;

namespace C____RPG
{
    class Graphics
    {
        private int tileSize;
        private int width;
        private int height;

        private Texture2D texture;

        public Graphics(Texture2D t, int gTile, int gWidth, int gHeight)
        {
            texture = t;
            tileSize = gTile;
            width = gWidth;
            height = gHeight;
        }

        public void draw( SpriteBatch sb )
        {
            Vector2 tilePos = Vector2.Zero;

            sb.Begin();

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    sb.Draw(texture, new Rectangle(width, height, tileSize, tileSize), Color.White);
                    tilePos.Y += height;
                }
                tilePos.Y = 0;
                tilePos.X += width;
            }

            sb.End();
        }
    }
}