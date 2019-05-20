using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShootEmUp.Libraries;
using ShootEmUp.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUp
{
    class Background : GameObject
    {
        Vector2 mySecondPosition;
        float mySpeed;
        Texture2D mySecondTexture;


        public Background() :
            base(TextureLibrary.GetTexture("SpaceBackground"), new Rectangle())
        {
            mySecondTexture = TextureLibrary.GetTexture("SpaceBackground");
            mySecondPosition = new Vector2(0, mySecondTexture.Height);
            mySpeed = 100;
        }

        public override void Update(GameTime someTime)
        {
            Vector2 myMovement = new Vector2(0, mySpeed * (float)someTime.ElapsedGameTime.TotalSeconds);
            AccessPosition += myMovement;
            mySecondPosition += myMovement;

            if(AccessPosition.Y > 20)
            {
                AccessPosition = new Vector2(0, -mySecondTexture.Height);
            }

            if(mySecondPosition.Y > 20)
            {
                mySecondPosition = new Vector2(0, -mySecondTexture.Height);
            }
        }

        public override void Draw(GameTime someTime, SpriteBatch aSpriteBatch)
        {
            aSpriteBatch.Draw(AccessTexture, new Rectangle(AccessPosition.ToPoint(), new Point(2000)), Color.White);
            aSpriteBatch.Draw(mySecondTexture, new Rectangle(mySecondPosition.ToPoint(), new Point(2000)), Color.White);
        }
    }
}
