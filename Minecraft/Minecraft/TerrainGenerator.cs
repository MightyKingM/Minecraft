using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft
{
    class TerrainGenerator
    {
        public Texture2D water;
        public Texture2D landbase;
        public Texture2D landheight1;
        public Texture2D landheight2;
        Random rand;
        public int seed
        {
            get;
            set;
        }
        public TerrainGenerator(Texture2D water, Texture2D landbase, Texture2D landheight1, Texture2D landheight2)
        {
            rand = new Random(seed);
            this.landbase = landbase;
            this.landheight1 = landheight1;
            this.landheight2 = landheight2;
            this.water = water;
        }
        public Platform GenerateTerrain(int screenwidth, int screenheight, int seed)
        {
            rand = new Random(seed);
            Platform Tiles = new Platform();
            int gen = rand.Next(0, 4);
            Tiles.Tiles.Clear();
            Point vp;
            vp = new Point(rand.Next(0, screenwidth - 1200), rand.Next(0, screenheight - 1200));

            for (int i = 0; i < screenwidth; i = i + 50)
            {
                for (int s = 0; s < screenheight; s = s + 50)
                {
                    gen = rand.Next(0, 10);
                    Tiles.Tiles.Add(new Block(landbase, new Microsoft.Xna.Framework.Point(i, s), "Dirt"));
                    if (gen == 1)
                    {
                        Tiles.Tiles.Add(new Block(landheight1, new Microsoft.Xna.Framework.Point(i, s), "Bush"));
                        createmountain(Tiles, new Point(i, s), landheight1, rand.Next(5, 20), screenwidth, screenheight, "Bush");
                    }
                    if (rand.Next(1, 1000) == 1)
                    {
                        // rand.Next(20,90)
                        createlargeM(Tiles, new Point(i, s), water, rand.Next(10, 20), screenwidth, screenheight, "Stone");

                    }

                }
            }
            for (int i = 0; i < screenwidth; i = i + 50)
            {
                for (int s = 0; s < screenheight; s = s + 50)
                {
                    gen = rand.Next(0, 10);
                    if (gen == 1)
                    {
                        createmountain(Tiles, new Point(i, s), landheight2, rand.Next(2, 10), screenwidth, screenheight, "Bush");
                    }
                }
            }
            return Tiles;
        }
        public void createlargeM(Platform tiles, Point r, Texture2D texture, int size, int screenwidth, int screenheight, string ID)
        {
            Point p;
            for (int i = 0; i < screenwidth; i = i + 200)
            {
                for (int s = 0; s < screenheight; s = s + 200)
                {
                    p = new Point(i, s);
                    if (p.X <= r.X + size && p.X >= r.X - size && p.Y >= r.Y - size & p.Y <= r.Y + size)
                    {
                        createmountain(tiles, p, texture, rand.Next(10, 20), screenwidth, screenheight, ID);
                    }
                }
            }
        }
        public void createmountain(Platform tiles, Point r, Texture2D texture, int size, int screenwidth, int screenheight, string ID)
        {
            Point p;
            for (int i = 0; i < screenwidth; i = i + 200)
            {
                for (int s = 0; s < screenheight; s = s + 200)
                {
                    p = new Point(i, s);
                    if (p.X <= r.X + size && p.X >= r.X - size && p.Y >= r.Y - size & p.Y <= r.Y + size)
                    {
                        tiles.Tiles.Add(new Block(texture, p, ID));
                    }
                }
            }
        }
    }
}
