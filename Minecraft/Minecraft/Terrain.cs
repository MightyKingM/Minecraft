using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft
{
    class Terrain
    {
        public TerrainGenerator generator;
        public List<Platform> Areas;
        Random rand;
        Texture2D stone;
        public int currentplat =0;

        public Terrain(Texture2D water, Texture2D landbase, Texture2D landheight1, Texture2D landheight2)
        {
            generator = new TerrainGenerator(water, landbase, landheight1, landheight2);
            Areas = new List<Platform>();
            rand = new Random();
            stone = landheight1;
        }
        public void GenerateTerrain()
        {
            Areas.Clear();
            for(int i = 0; i < 9; i++)
            {
                Areas.Add(new Platform());
            }
            for (int i = 0; i < Areas.Count(); i++)
            {
                Areas[i] = generator.GenerateTerrain(3950,1700,rand.Next());
            }
        }
        public void Draw(SpriteBatch spritebatch)
        {
            Areas[currentplat].Draw(spritebatch);
        }
        public void BreakBlock(Rectangle rect,ref Inventory inv)
        {
            for (int i = 0; i < Areas[currentplat].Tiles.Count(); i++)
            {
                if (rect == Areas[currentplat].Tiles[i].rect)
                {
                    inv.AddItem(Areas[currentplat].Tiles[i]);
                    Areas[currentplat].Tiles.RemoveAt(i);
                    //Areas[currentplat].Tiles.Add(new Block(stone, new Point(rect.X, rect.Y), "Stone"));
                    break;
                }
            }
        }
        public void PlaceBlock(ref Inventory inv,Rectangle rect)
        {
            Areas[currentplat].Tiles.Add(new Block(inv.items[inv.selected].texture,new Point(rect.X,rect.Y), inv.items[inv.selected].ID));
        }
        public void Update(int areaida, int areaidb)
        {
            if(areaida == 1)
            {
                if(areaidb == 1)
                {
                    currentplat = 0;
                }
                if (areaidb == 2)
                {
                    currentplat = 1;
                }
                if (areaidb == 3)
                {
                    currentplat = 2;
                }
            }
            if (areaida == 2)
            {
                if (areaidb == 1)
                {
                    currentplat = 3;
                }
                if (areaidb == 2)
                {
                    currentplat = 4;
                }
                if (areaidb == 3)
                {
                    currentplat = 5;
                }
            }
            if (areaida == 3)
            {
                if (areaidb == 1)
                {
                    currentplat = 6;
                }
                if (areaidb == 2)
                {
                    currentplat = 7;
                }
                if (areaidb == 3)
                {
                    currentplat = 8;
                }
            }
        }
    }
}
