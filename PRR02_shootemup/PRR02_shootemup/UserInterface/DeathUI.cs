using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        string myDeathScreenText;
        bool isPlayerDead = false;
        KeyboardState myPreviousKeyboardState;

        public DeathUI() :
            base(null, new Rectangle())
        {
            myFont = FontLibrary.GetFont("Font");
        }

        public void ShowDeathScreen()
        {
            myDeathScreenText = "You died!\nPress R to restart\nPress escape to exit";
            isPlayerDead = true;
        }

        public override void Update(GameTime someTime)
        {
            KeyboardState tempKeyboardState = Keyboard.GetState();
            if (isPlayerDead)
            {
                if (StartedPress(Keys.R, tempKeyboardState))
                {
                    Game1.Restart();
                    Game1.AccessPlayer.AccessMoney = Game1.AccessPlayer.AccessScore = 0;
                }

                if (StartedPress(Keys.Escape, tempKeyboardState))
                {
                    Environment.Exit(0);
                }
            }
            myPreviousKeyboardState = tempKeyboardState;
        }

        public override void Draw(GameTime someTime, SpriteBatch aSpriteBatch)
        {
            if (myDeathScreenText == null)
            {
                return;
            }
            aSpriteBatch.DrawString(myFont, myDeathScreenText, new Vector2(900, 500), Color.White, 0, Vector2.Zero, 2, SpriteEffects.None, 1);
        }

        private bool StartedPress(Keys aKey, KeyboardState aCurrentKeyboardState)
        {
            return (aCurrentKeyboardState.IsKeyDown(aKey) && !myPreviousKeyboardState.IsKeyDown(aKey));
        }
    }
}
