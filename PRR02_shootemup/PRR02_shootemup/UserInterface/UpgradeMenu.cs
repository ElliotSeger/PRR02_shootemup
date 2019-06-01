using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShootEmUp.Collectibles;
using ShootEmUp.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUp.UserInterface
{
    class UpgradeMenu
    {
        SpriteFont myFont;
        string myText;
        KeyboardState myPreviousKeyboardState;

        public UpgradeMenu()
        {
            myText = "Press J to upgrade your max health to 200 for 3 coins! \nPress K to upgrade your max speed for 5 coins! \nPress L to next level!";
            myFont = FontLibrary.GetFont("Font");
        }

        public void Update(GameTime someTime)
        {
            KeyboardState tempKeyboardState = Keyboard.GetState();

            // Låter spelaren uppgradera sin hälsa för 3 mynt om spelaren har lägre än 200 maxhälsa.
            if (StartedPress(Keys.J, tempKeyboardState) && Game1.AccessPlayer.AccessMoney >= 3 && Game1.AccessPlayer.AccessHealth < 200)
            {
                Game1.AccessPlayer.AccessHealth = 200;
                Game1.AccessPlayer.AccessMoney -= 3;
            }

            // Låter spelaren uppgradera sin fart för 5 mynt om spelaren har lägre än maxfarten. 
            if (StartedPress(Keys.K, tempKeyboardState) && Game1.AccessPlayer.AccessMoney >= 5 && Game1.AccessPlayer.AccessSpeed < 550)
            {
                Game1.AccessPlayer.AccessSpeed = 550;
                Game1.AccessPlayer.AccessMoney -= 5;
            }

            if (StartedPress(Keys.L, tempKeyboardState))
            {
                Game1.myIsShowingUpgradeMenu = false;
            }
            myPreviousKeyboardState = tempKeyboardState;
        }

        public void Draw(SpriteBatch aSpriteBatch)
        {
            aSpriteBatch.DrawString(myFont, myText, new Vector2(500, 500), Color.White, 0, Vector2.Zero, 2, SpriteEffects.None, 1);
        }

        private bool StartedPress(Keys aKey, KeyboardState aCurrentKeyboardState)
        {
            return (aCurrentKeyboardState.IsKeyDown(aKey) && !myPreviousKeyboardState.IsKeyDown(aKey));
        }
    }
}
