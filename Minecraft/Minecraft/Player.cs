using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft
{
    class Player
    {
        public Texture2D TA;
        public Texture2D TB;
        public Texture2D TC;
        public Texture2D TD;
        public Texture2D Hitzone;
        //public MouseState ms;
        public Rectangle hitbox;
        public Rectangle rect;
        public int areaida = 1;
        public int areaidb = 1;
        public int direction;
        public int health = 5;
        public Player(Texture2D TA, Texture2D TB, Texture2D TC, Texture2D TD, Texture2D Hitzone, Rectangle rect)
        {
            this.TA = TA;
            this.TB = TB;
            this.TC = TC;
            this.TD = TD;
            this.rect = rect;
            this.Hitzone = Hitzone;
        }
        public void Hit(List<Mob> mobs, int index)
        {
            if(Hitzone == mobs[index].self.Hitzone)
            {
                mobs[index].self.health--;
            }
            if(mobs[index].self.health == 0)
            {
                mobs.RemoveAt(index);
            }
        }
        public void Draw(SpriteBatch SB)
        {
            if (direction == 1)
            {
                SB.Draw(TA, rect, Color.White);
            }
            if (direction == 2)
            {
                SB.Draw(TB, rect, Color.White);
            }
            if (direction == 3)
            {
                SB.Draw(TC, rect, Color.White);
            }
            if (direction == 4)
            {
                SB.Draw(TD, rect, Color.White);
            }
            SB.Draw(Hitzone,hitbox, Color.Red * 0.2f);
        }
        public void Update(KeyboardState KS,KeyboardState PK, ref Terrain terrain,ref Inventory inv,int width,int height)
        {
            if (rect.X <= 1)
            {
                if (areaida != 1)
                {
                    areaida--;
                    rect.X = 3800;
                }
            }
            if (rect.Y - rect.Height < 1)
            {
                if (areaidb != 3)
                {
                    areaidb++;
                    rect.Y = 1400;
                }
            }
            if (rect.X + rect.Width > width)
            {
                if (areaida != 3)
                {
                    areaida++;
                    rect.X = 100;
                }

            }
            if (rect.Y > height)
            {
                if (areaidb != 1)
                {
                    rect.Y = 400;
                    areaidb--;
                }
            }
            if (PK.IsKeyDown(Keys.LeftShift) && KS.IsKeyUp(Keys.LeftShift))
            {
                terrain.BreakBlock(hitbox, ref inv);
            }
            if (PK.IsKeyDown(Keys.RightShift) && KS.IsKeyUp(Keys.RightShift))
            {
                terrain.PlaceBlock(ref inv, hitbox);
            }
            if (PK.IsKeyDown(Keys.W) &&  KS.IsKeyUp(Keys.W))
            {
                direction = 1;
                rect.Y = rect.Y - 50;
                hitbox = new Rectangle(rect.X, rect.Y - rect.Height, 50, 50);
            }
            if (PK.IsKeyDown(Keys.A) && KS.IsKeyUp(Keys.A))
            {
                direction = 4;
                rect.X = rect.X - 50;
                hitbox = new Rectangle(rect.X - 1 * rect.Width, rect.Y, 50, 50);
            }
            if (PK.IsKeyDown(Keys.S) && KS.IsKeyUp(Keys.S))
            {
                direction = 3;
                rect.Y = rect.Y + 50;
                hitbox = new Rectangle(rect.X, rect.Y + 1 * rect.Height, 50, 50);
            }
            if (PK.IsKeyDown(Keys.D) && KS.IsKeyUp(Keys.D))
            {
                direction = 2;
                rect.X = rect.X + 50;
                hitbox = new Rectangle(rect.X + rect.Width, rect.Y, 50, 50);
            }
        }
    }
}
