using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShootEmUp.Libraries;
using ShootEmUp.Objects;
using ShootEmUp.Objects.Creatures.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUp.UserInterface
{
    class DeathUI : GameObject
    {
        SpriteFont myFont;
        string myDeathScreen;

        public DeathUI() :
            base(null, new Rectangle())
        {
            myFont = FontLibrary.GetFont("Font");
        }

        public void ShowDeathScreen(string aDeathScreen)
        {
            myDeathScreen += aDeathScreen;
        }

        public override void Draw(GameTime someTime, SpriteBatch aSpriteBatch)
        {
            aSpriteBatch.DrawString(myFont, "", new Vector2(500, 500), Color.White);
        }
    }
}
