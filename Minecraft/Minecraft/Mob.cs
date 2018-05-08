using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft
{
    class Mob
    {
        public Player self;
        Random rand;
        public int areaida = 1;
        public int areaidb = 1;

        public Mob(Texture2D TA, Texture2D TB, Texture2D TC, Texture2D TD, Texture2D Hitzone, Rectangle rect)
        {
            self = new Player(TA, TB, TC, TD, Hitzone, rect);
            rand = new Random();
        }
        public void Move(int width, int height)
        {
            int move = rand.Next(1,250);
            if(move == 1)
            {
                self.direction = 1;
                self.rect.Y = self.rect.Y - 50;
            }
            if(move ==2)
            {
                self.direction = 2;
                self.rect.X = self.rect.X + 50;
            }
            if(move == 3)
            {
                self.direction = 3;
                self.rect.Y = self.rect.Y - 50;
            }
            if(move == 4)
            {
                self.direction = 4;
                self.rect.X = self.rect.X + 50;
            }
            if (self.rect.X <= 1)
            {
                if (areaida != 1)
                {
                    areaida--;
                    self.rect.X = 3800;
                }
            }
            if (self.rect.Y - self.rect.Height < 1)
            {
                if (areaidb != 3)
                {
                    areaidb++;
                    self.rect.Y = 1400;
                }
            }
            if (self.rect.X + self.rect.Width > width)
            {
                if (areaida != 3)
                {
                    areaida++;
                    self.rect.X = 100;
                }

            }
            if (self.rect.Y > height)
            {
                if (areaidb != 1)
                {
                    self.rect.Y = 400;
                    areaidb--;
                }
            }
        }
        public void Draw(SpriteBatch SB)
        {
            self.Draw(SB);
        }
    }
}
