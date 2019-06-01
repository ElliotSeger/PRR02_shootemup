using Microsoft.Xna.Framework;
using ShootEmUp.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUp.Objects.Creatures.Enemies
{
    class EnemyShipGamma : BaseEnemy
    {
        float myElapsedTime = 0;
        float myDamage = 30;

        public EnemyShipGamma(Point aPosition) :
            base(TextureLibrary.GetTexture("EnemyShip"), new Rectangle(aPosition.X, aPosition.Y, 64, 48), 20, 50)
        {
            AccessSpeed = 150;
        }

        public override void Update(GameTime someTime)
        {
            float tempDeltaTime = (float)someTime.ElapsedGameTime.TotalSeconds;
            myElapsedTime += tempDeltaTime;

            if (myElapsedTime >= 0.3f)
            {
                myElapsedTime = 0;
                Game1.myObjects.Add(new Bullet(Vector2.UnitY, AccessRectangle.Location.ToVector2(), myDamage, 15, this));
            }

            Move(someTime, Vector2.UnitY);

            base.Update(someTime);
        }
    }
}
