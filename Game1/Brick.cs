using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class Brick
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public bool Visible { get; set; }
        private Color color;

        private Texture2D imgBrick { get; set; }
        private SpriteBatch spriteBatch { get; set; }

        public Brick(float x, float y, Color color, SpriteBatch spriteBatch, GameContent gameContent)
        {
            X = x;
            Y = y;
            imgBrick = gameContent.imgBrick;
            Width = gameContent.imgBrick.Width;
            Height = gameContent.imgBrick.Height;
            Visible = true;
            this.spriteBatch = spriteBatch;
            this.color = color;
        }

        public void Draw()
        {
            if (Visible)
            {
                spriteBatch.Draw(imgBrick, new Vector2(X, Y), null, color,
                    0, new Vector2(0,0), 1.0f, SpriteEffects.None, 0 );
            }
        }
    }
}
