using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ShootEmUp.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUp.Objects.Creatures.Player
{
    class PlayerSoldier : Creature
    {
        float mySpeed;
        Vector2 myMoveDirection; 
        float myElapsedTime = 0;

        public PlayerSoldier() :
            base(TextureLibrary.GetTexture("Player"), new Rectangle(750, 750, 100, 100), 100, 100)
        {
            mySpeed = 300;
        }

        public override void Update(GameTime someTime)
        {
            float tempDeltaTime = (float)someTime.ElapsedGameTime.TotalSeconds;
            myElapsedTime += tempDeltaTime;
            myMoveDirection = new Vector2();
            KeyboardState aKeyBoardState = Keyboard.GetState();
            Rectangle tempRectangle = AccessRectangle;

            if (aKeyBoardState.IsKeyDown(Keys.A))
            {
                myMoveDirection.X = -1;
            }

            if (aKeyBoardState.IsKeyDown(Keys.D))
            {
                myMoveDirection.X = 1;
            }

            if (aKeyBoardState.IsKeyDown(Keys.Space))
            {
                myMoveDirection.Y = -1;
            }

            if (myMoveDirection != Vector2.Zero)
            {
                myMoveDirection.Normalize();
                AccessPosition += myMoveDirection * mySpeed * tempDeltaTime;
            }

            
        }
    }
}
