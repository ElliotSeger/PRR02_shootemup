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
    class MoneyUI : GameObject
    {
        SpriteFont myFont;

        public MoneyUI() :
            base(null, new Rectangle())
        {
            myFont = FontLibrary.GetFont("Font");
        }

        public void AddCoins(int someMoney)
        {
            Game1.AccessPlayer.AccessMoney += someMoney;
        }

        public override void Draw(GameTime someTime, SpriteBatch aSpriteBatch)
        {
            aSpriteBatch.DrawString(myFont, $"Money {Game1.AccessPlayer.AccessMoney}", new Vector2(50, 100), Color.White);
        }
    }
}
