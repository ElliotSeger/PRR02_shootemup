using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShootEmUp.Libraries;
using Microsoft.Xna.Framework;
using ShootEmUp.Objects;
using ShootEmUp.Objects.Creatures.Player;

namespace ShootEmUp.UI
{
    class HealthUI : GameObject
    {
        SpriteFont myFont;
        int myHealth;
        PlayerShip myPlayerShip;

        public HealthUI() :
            base(null, new Rectangle())
        {
            myFont = FontLibrary.GetFont("Font");
            myPlayerShip = Game1.myObjects.Where(x => x is PlayerShip).First() as PlayerShip;
        }

        public void DecreaseHealth(int aHealth)
        {
            myHealth =- aHealth;
        }

        public override void Draw(GameTime someTime, SpriteBatch aSpriteBatch)
        {
            aSpriteBatch.DrawString(myFont, $"Health {myPlayerShip.AcccessHealth}", new Vector2(1000, 50), Color.White);
        }
    }
}
