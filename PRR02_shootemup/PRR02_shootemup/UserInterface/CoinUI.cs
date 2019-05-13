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
        PlayerSoldier myPlayer;

        public CoinUI() :
            base(null, new Rectangle())
        {
            myFont = FontLibrary.GetFont("Font");
            myPlayer = Game1.myObjects.Where(x => x is PlayerSoldier).First() as PlayerSoldier;
        }

        public void IncreaseCoins()
        {

        }

        public override void Draw(GameTime someTime, SpriteBatch aSpriteBatch)
        {
            aSpriteBatch.DrawString(myFont, $"Coins: ", new Vector2(1000, 100), Color.White);
        }
    }
}
