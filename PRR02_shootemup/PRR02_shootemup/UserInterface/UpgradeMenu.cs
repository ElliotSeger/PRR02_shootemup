using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
            myText = "Press K to buy! \nPress L to next level!";
            myFont = FontLibrary.GetFont("Font");
        }

        public void Update(GameTime someTime)
        {
            KeyboardState tempKeyboardState = Keyboard.GetState();

            if (StartedPress(Keys.K, tempKeyboardState))
            {
                Game1.AccessPlayer.AccessSpeed = 1000;
            }

            if (StartedPress(Keys.L, tempKeyboardState))
            {
                Game1.myIsShowingUpgradeMenu = false;
            }
            myPreviousKeyboardState = tempKeyboardState;
        }

        public void Draw(SpriteBatch aSpriteBatch)
        {
            aSpriteBatch.DrawString(myFont, myText, new Vector2(900, 500), Color.White, 0, Vector2.Zero, 2, SpriteEffects.None, 1);
        }

        private bool StartedPress(Keys aKey, KeyboardState aCurrentKeyboardState)
        {
            return (aCurrentKeyboardState.IsKeyDown(aKey) && !myPreviousKeyboardState.IsKeyDown(aKey));
        }
    }
}
