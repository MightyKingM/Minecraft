using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Xna.Framework;

namespace Minecraft
{
    class WorldFileSaver
    {
        bool installed = false;
       
        
        public WorldFileSaver()
        {
            if (Directory.Exists("C:\\GameData\\Minecraft"))
            {
                installed = true;
            }
        }
        public List<string> GetPlatData(Platform plat)
        {
            List<string> toret = new List<string>();
            for(int i = 0; i < plat.Tiles.Count; i++)
            {
                toret.Add(plat.Tiles[i].ID);
            }
            return toret;
        }
        public Platform ConvertToPlat(List<string> Data,ref TerrainGenerator tg)
        {
            Platform platform = new Platform();
            
            int y = 0;
            int e = 0;
            for(int i = 0; i < Data.Count; i++)
            {
                e++;
                if(e > 79)
                {
                    e = 0;
                    if(y <1700)
                    y = y + 50;
                }
                if(Data[i] == "Dirt")
                {
                    platform.Tiles.Add(new Block(tg.landbase, new Point(e * 50, y), Data[i]));
                }
                if (Data[i] == "Stone")
                {
                    platform.Tiles.Add(new Block(tg.water, new Point(e * 50, y), Data[i]));
                }
                if (Data[i] == "Bush")
                {
                    platform.Tiles.Add(new Block(tg.landheight1, new Point(e * 50, y), Data[i]));
                }
                if (Data[i] == "Water")
                {
                    platform.Tiles.Add(new Block(tg.landheight2, new Point(e * 50, y), Data[i]));
                }
                
            }return platform;
        }
        public void GetAllData(ref Terrain terrain)
        {
            terrain.Areas.Clear();
            for(int i=0; i < 9; i++)
            {
               terrain.Areas.Add(ConvertToPlat(File.ReadAllLines("C:\\GameData\\Minecraft\\Platform" + i + ".txt").ToList(),
                   ref terrain.generator));
            }
        }
        public void PushAllData(Terrain terrain)
        {

            for(int i = 0; i < terrain.Areas.Count;i++)
            {
                File.WriteAllLines("C:\\GameData\\Minecraft\\Platform" + i + ".txt", GetPlatData(terrain.Areas[i]));
            }
        }
        public void Install()
        {
            if (Directory.Exists("C:\\GameData"))
            {
                if (Directory.Exists("C:\\GameData\\Minecraft"))
                {

                }
                else
                {
                    Directory.CreateDirectory("C:\\GameData\\Minecraft");
                }
            }
            else
            {
                Directory.CreateDirectory("C:\\GameData");
                Directory.CreateDirectory("C:\\GameData\\Minecraft");
            }
            for (int i = 0; i < 9; i++)
            {
                var b = File.Create("C:\\GameData\\Minecraft\\Platform" + i + ".txt");
                b.Close();
                b.Dispose();
            }
            var x = File.Create("C:\\GameData\\Minecraft\\Player.txt");
            x.Close();
            x.Dispose();
            var a = File.Create("C:\\GameData\\Minecraft\\SETTINGS.txt");
            a.Close();
            string[] settings = { "Minecraft 2D 1.0 SETTINGS", "savedata=true", "reset=false" };
            File.WriteAllLines("C:\\GameData\\Minecraft\\SETTINGS.txt", settings);
        }
    }

}
