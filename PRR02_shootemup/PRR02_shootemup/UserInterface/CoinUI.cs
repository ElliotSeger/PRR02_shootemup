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
    class CoinUI : GameObject
    {
        SpriteFont myFont;
        int myCoins;

        public CoinUI() :
            base(null, new Rectangle())
        {
            myFont = FontLibrary.GetFont("Font");
        }

        public void AddCoins(int aCoins)
        {
            myCoins += aCoins;
        }

        public override void Draw(GameTime someTime, SpriteBatch aSpriteBatch)
        {
            aSpriteBatch.DrawString(myFont, $"Coins {myCoins}", new Vector2(50, 100), Color.White);
        }
    }
}
