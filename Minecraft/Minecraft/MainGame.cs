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
    class MainGame
    {
        public Player player;
        public Terrain terrain;
        public Inventory inventory;
        public List<Mob> mobs;
        public Random rand;
        public Player zombie;
        public MainGame(Texture2D TA, Texture2D TB, Texture2D TC, Texture2D TD, Texture2D Hitzone,
        Rectangle rect, Texture2D water, Texture2D landbase, Texture2D landheight1, Texture2D landheight2, Texture2D pointer,
        SpriteFont mainFont, Texture2D ZombiB, Texture2D ZombiL, Texture2D ZombiT, Texture2D ZombiR)
        {
            player = new Player(TA, TB, TC, TD, Hitzone, rect);
            terrain = new Terrain(water, landbase, landheight1, landheight2);
            inventory = new Inventory(pointer);
            mobs = new List<Mob>();
            rand = new Random();
            zombie = new Player(ZombiT, ZombiR, ZombiB, ZombiL, Hitzone, new Rectangle());
        }
        public void Initialize()
        {
            terrain.GenerateTerrain();
            terrain.Update(player.areaida,player.areaidb);
            
        }
        
        public void Update(KeyboardState KS,KeyboardState PK)
        {
            player.Update(KS, PK, ref terrain,ref inventory, 2950, 1470);
            terrain.Update(player.areaida, player.areaidb);
            inventory.Update(KS, PK);
            for (int i = 0; i < mobs.Count(); i++)
            {
                mobs[i].Move(2950, 1470);
            }
            if (new Random().Next(200) == 1 && mobs.Count <= 1000) 
            {
                mobs.Add(new Mob(zombie.TA, zombie.TB, zombie.TC, zombie.TD, zombie.Hitzone, new Rectangle(new Random().Next(100,300),new Random().Next(100,300),50, 50)));
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            terrain.Draw(spriteBatch);
            player.Draw(spriteBatch);
            inventory.Draw(spriteBatch);
            for(int i = 0; i < mobs.Count(); i++)
            {
                if (mobs[i].areaida == player.areaida && mobs[i].areaidb == player.areaidb)
                {
                    mobs[i].Draw(spriteBatch);
                }
            }
        }
    }
}
