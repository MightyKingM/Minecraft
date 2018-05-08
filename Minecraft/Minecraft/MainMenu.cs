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
    class MainMenu
    {
        public Texture2D mainscreen;
        public MainMenu(Texture2D mainscreen)
        {
            this.mainscreen = mainscreen;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(mainscreen, new Rectangle(0, 0, 4000, 2000), Color.White);
        }
        public string Update(MouseState ms)
        {
            if(ms.LeftButton == ButtonState.Pressed)
            {
                ;
            }
            if(ms.LeftButton == ButtonState.Pressed && ms.X >= 1005 && ms.X <=2100
                && ms.Y >=906 && ms.Y <= 1230)
            {
                return "BUTTON1";
            }
            if (ms.LeftButton == ButtonState.Pressed && ms.X >= 1005 && ms.X <= 2100
                && ms.Y >= 1275 && ms.Y <= 1581)
            {
                return "BUTTON2";
            }

            return "NONE";
        }

    }
}
