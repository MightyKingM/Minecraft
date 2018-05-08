using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft
{
    class Platform
    {
        public List<Block> Tiles;
        public Platform()
        {
            Tiles = new List<Block>();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for(int i = 0; i<Tiles.Count; i++)
            {
                spriteBatch.Draw(Tiles[i].texture, Tiles[i].rect,Color.White);
            }
        }
        
    }
}
