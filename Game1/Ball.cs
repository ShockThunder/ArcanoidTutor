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
    class Ball
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Xvelocity { get; set; }
        public float Yvelocity { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Rotation { get; set; }
        public bool UseRotation { get; set; }
        public float ScreenWidth { get; set; }
        public float ScreenHeight { get; set; }
        public bool Visible { get; set; }
        public int Score { get; set; }
        public int bricksCleared { get; set; }

        private Texture2D imgBall { get; set; }
        private SpriteBatch spriteBatch { get; set; }
        private GameContent gameContent;

        public Ball(float screenWidth, float screenHeight, SpriteBatch spriteBatch, GameContent gameContent)
        {
            X = 0;
            Y = 0;
            Xvelocity = 0;
            Yvelocity = 0;
            Rotation = 0;
            imgBall = gameContent.imgBall;
            Width = imgBall.Width;
            Height = imgBall.Height;
            this.spriteBatch = spriteBatch;
            this.gameContent = gameContent;
            ScreenWidth = screenWidth;
            ScreenHeight = screenHeight;
            Visible = false;
            Score = 0;
            bricksCleared = 0;
            UseRotation = true;

        }

        public void Draw()
        {
            if (!Visible)
            {
                return;
            }

            if (UseRotation)
            {
                Rotation += .1f;
                if (Rotation > 3*Math.PI)
                {
                    Rotation = 0;
                }
            }

            spriteBatch.Draw(imgBall, new Vector2(X,Y), null, Color.White, Rotation,
                new Vector2(Width/2, Height/2), 1.0f, SpriteEffects.None,0 );
        }

        public void Launch(float x, float y, float xvelocity, float yvelocity)
        {
            if (Visible)
            {
                return;
            }
            PlaySound(gameContent.startSound);
            Visible = true;
            X = x;
            Y = y;
            Xvelocity = xvelocity;
            Yvelocity = yvelocity;
        }

        public bool Move(Wall wall, Paddle paddle)
        {
            if (!Visible)
            {
                return false;
            }

            X = X + Xvelocity;
            Y = Y + Yvelocity;

            //check for wall hits
            if (X<1)
            {
                X = 1;
                Xvelocity = Xvelocity * -1;
                PlaySound(gameContent.wallBounceSound);
            }

            if (X > ScreenWidth - Width + 5)
            {
                Xvelocity = Xvelocity * -1;
                PlaySound(gameContent.wallBounceSound);
            }

            if (Y<1)
            {
                Y = 1;
                Yvelocity = Yvelocity * -1;
                PlaySound(gameContent.wallBounceSound);
            }

            if (Y+Height > ScreenHeight)
            {
                Visible = false;
                Y = 0;
                PlaySound(gameContent.missSound);
                return false;
            }

            Rectangle paddleRectangle = new Rectangle((int)paddle.X, (int)paddle.Y, (int)paddle.Width, (int)paddle.Height);
            Rectangle ballRectangle = new Rectangle((int)X, (int)Y, (int)Width, (int)Height);

            if (HitTest(paddleRectangle,ballRectangle))
            {
                PlaySound(gameContent.paddleBounceSound);
                int offset = Convert.ToInt32((paddle.Width - (paddle.X + paddle.Width - X + Width / 2)));

                offset = offset / 5;
                if (offset < 0)
                {
                    offset = 0;
                }

                switch (offset)
                {
                    case 0:
                        Xvelocity = -6;
                        break;
                    case 1:
                        Xvelocity = -5;
                        break;
                    case 2:
                        Xvelocity = -4;
                        break;
                    case 3:
                        Xvelocity = -3;
                        break;
                    case 4:
                        Xvelocity = -2;
                        break;
                    case 5:
                        Xvelocity = -1;
                        break;
                    case 6:
                        Xvelocity = 1;
                        break;
                    case 7:
                        Xvelocity = 2;
                        break;
                    case 8:
                        Xvelocity = 3;
                        break;
                    case 9:
                        Xvelocity = 4;
                        break;
                    case 10:
                        Xvelocity = 5;
                        break;
                    default:
                        Xvelocity = 6;
                        break;
                    }

                Yvelocity = Yvelocity * -1;
                Y = paddle.Y - Height + 1;
                return true;
            }

            bool hitBrick = false;
            for (int i = 0; i < 7; i++)
            {
                if (!hitBrick)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Brick brick = wall.BrickWall[i, j];
                        if (brick.Visible)
                        {
                            Rectangle brickRectangle = new Rectangle((int)brick.X, (int)brick.Y, (int)brick.Width, (int)brick.Height);
                            if (HitTest(ballRectangle, brickRectangle))
                            {
                                PlaySound(gameContent.brickSound);
                                brick.Visible = false;
                                Score = Score + 7 - i;
                                Yvelocity = Yvelocity * -1;
                                bricksCleared++;
                                hitBrick = true;
                                break;
                            }
                        }
                    }
                }
            }

            return true;
        }

        public static bool HitTest(Rectangle r1, Rectangle r2)
        {
            if (Rectangle.Intersect(r1, r2) != Rectangle.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public static void PlaySound(SoundEffect sound)
        {
            float volume = 1;
            float pitch = 0.0f;
            float pan = 0.0f;
            sound.Play(volume, pitch, pan);
        }
    }
}
