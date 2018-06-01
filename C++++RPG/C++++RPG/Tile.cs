using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C____RPG
{
    class Tile
    {
        protected Texture2D texture;

        private Rectangle rectangle;
        public Rectangle Rectangle
        {
            get { return rectangle;  }
            protected set { rectangle = value; }
        }

        private static ContentManager content;
        public static ContentManager Content
        {
            protected get { return content; }
            set { content = value; }
        }

        private int currentFrame;
        private int totalFrames;
        public void UpdateFrames()
        {
            currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = 0;
        }

        private int fps;
        public void Draw(SpriteBatch sb)
        {
            fps++;
            if (fps > 40)
            {
                UpdateFrames();
                fps = 0;
            }

            int height = rectangle.Height;
            totalFrames = texture.Height / height;

            //Draw a big picture
            if (texture.Height > height && texture.Width > height && texture.Height == texture.Width)
            {
                rectangle.Y = (rectangle.Y - texture.Height) + height;
                rectangle.Height = texture.Height;
                rectangle.Width = texture.Width;

                sb.Draw(texture,
                    rectangle,
                    new Rectangle(0, texture.Height, texture.Width, texture.Height),
                    Color.White
                );
            }
            //Draw a BIG animated sprite
            else if (texture.Height > height && texture.Width > height)
            {
                rectangle.Y -= height;
                rectangle.Height = texture.Width;
                rectangle.Width = texture.Width;

                sb.Draw(texture,
                    rectangle,
                    new Rectangle(0, (currentFrame * texture.Height), texture.Width, texture.Height),
                    Color.White
                );
            }
            //Draw an animated sprite
            else if (texture.Height > height)
            {
                sb.Draw(texture,
                    rectangle,
                    new Rectangle(0, (currentFrame * height), rectangle.Height, rectangle.Height),
                    Color.White
                );
            }
            else //Draw a single sprite
            {
                sb.Draw(texture, rectangle, Color.White);
            }
        }
    }

    class CollisionTiles : Tile
    {
        public CollisionTiles(double i, Rectangle newRectangle)
        {
            texture = Content.Load<Texture2D>("tiles\\tile" + i);
            this.Rectangle = newRectangle;
        }
    }
}
