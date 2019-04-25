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
    class GameBorder
    {
        public float Width { get; set; }
        public float Height { get; set; }

        private Texture2D imgPixel { get; set; }
        private SpriteBatch spriteBatch { get; set; }

        public GameBorder(float screenWidth, float screenHeight, SpriteBatch spriteBatch, GameContent gameContent)
        {
            Width = screenWidth;
            Height = screenHeight;
            this.spriteBatch = spriteBatch;
            imgPixel = gameContent.imgPixel;
        }

        public void Draw()
        {
            spriteBatch.Draw(imgPixel, new Rectangle(0,0,(int)Width - 1, 1),Color.White);
            spriteBatch.Draw(imgPixel, new Rectangle(0, 0, 1, (int)Height - 1), Color.White);
            spriteBatch.Draw(imgPixel, new Rectangle((int)Width - 1, 0, 1, (int)Height - 1), Color.White);
        }
    }
}
