using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class GameContent
    {
        public Texture2D imgBrick { get; set; }
        public Texture2D imgPaddle { get; set; }
        public Texture2D imgBall { get; set; }
        public Texture2D imgPixel { get; set; }

        public SoundEffect startSound { get; set; }
        public SoundEffect brickSound { get; set; }
        public SoundEffect paddleBounceSound { get; set; }
        public SoundEffect wallBounceSound { get; set; }
        public SoundEffect missSound { get; set; }

        public SpriteFont labelFont { get; set; }

        public GameContent(ContentManager Content)
        {
            imgBall = Content.Load<Texture2D>("Ball");
            imgBrick = Content.Load<Texture2D>("Brick");
            imgPaddle = Content.Load<Texture2D>("Paddle");
            imgPixel = Content.Load<Texture2D>("Pixel");

            startSound = Content.Load<SoundEffect>("StartSound");
            brickSound = Content.Load<SoundEffect>("BrickSound");
            paddleBounceSound = Content.Load<SoundEffect>("PaddleBounceSound");
            wallBounceSound = Content.Load<SoundEffect>("WallBounceSound");
            missSound = Content.Load<SoundEffect>("MissSound");

            labelFont = Content.Load<SpriteFont>("Arial20");
        }
    }
}
