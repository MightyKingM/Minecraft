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
    class Inventory
    {
        public List<Block> items;
        List<int> hotbar;
        Texture2D selectionbox;
        public int selected= 0;
        public Inventory(Texture2D selectionbox)
        {
            items = new List<Block>();
            hotbar = new List<int>();
            this.selectionbox = selectionbox;
        }
        public void AddItem(Block block)
        {
            items.Add(block);
            if(items.Count <= 25)
            {
                hotbar.Add(items.Count() - 1);
            }
        }
        public void Update(KeyboardState KS, KeyboardState PK)
        {
            if (KS.IsKeyUp(Keys.Right) && PK.IsKeyDown(Keys.Right))
            {
                if(selected != items.Count)
                {
                    selected++;
                }
            }
            if(KS.IsKeyUp(Keys.Left) && PK.IsKeyDown(Keys.Left))
            {
                if(selected!=0)
                {
                    selected--;
                }
            }
        }
        public void Draw(SpriteBatch SB)
        {
            SB.Draw(selectionbox, new Rectangle(selected * 100 + 100, 1850, 95, 95), Color.White);
            for(int i = 0; i < hotbar.Count(); i++)
            {
                SB.Draw(items[hotbar[i]].texture, new Rectangle(100 + i * 100, 1750, 95, 95), Color.White);
            }
        }
        
    }
}
