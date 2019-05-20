using Microsoft.Xna.Framework;
using ShootEmUp.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUp.Objects.Creatures.Enemies
{
    class EnemyShipBeta : BaseEnemy
    {
        public EnemyShipBeta() :
            base(TextureLibrary.GetTexture("EnemyShip"), new Rectangle(500, 200, 64, 48), 10)
        {
            AccessSpeed = 100;
        }

        float myElapsedTime = 0;
        float myDamage = 10;

        int myDirectionCount = 3;
        float myTotalShootingAngle = 1;
        float myCenterAngle = MathHelper.PiOver2;

        public override void Update(GameTime someTime)
        {
            float tempDeltaTime = (float)someTime.ElapsedGameTime.TotalSeconds;
            myElapsedTime += tempDeltaTime;

            if (myElapsedTime >= 0.8f)
            {
                myElapsedTime = 0;
                Shoot();
            }

            if (AcccessHealth <= 0)
            {
                Game1.myObjects.Remove(this);
                (Game1.myObjects.Where(x => x is ScoreUI).First() as ScoreUI).AddScore(75);
            }

            Move(someTime, Vector2.UnitY);
        }

        private void Shoot()
        {
            float tempAnglePerShot = myTotalShootingAngle / (myDirectionCount - 1);

            for (int i = 0; i < myDirectionCount; ++i)
            {
                float tempAngle = tempAnglePerShot * i + myCenterAngle - myTotalShootingAngle * 0.5f;
                Vector2 tempDirection = new Vector2((float)Math.Cos(tempAngle), (float)Math.Sin(tempAngle));
                Game1.myObjects.Add(new Bullet(tempDirection, AccessRectangle.Location.ToVector2(), myDamage, 12, this));
            }
        }

        
    }
}
