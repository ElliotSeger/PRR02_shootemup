using Microsoft.Xna.Framework;
using ShootEmUp.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUp.Objects.Creatures.Enemies
{
    class EnemyBoss1 : BaseEnemy
    {
        public EnemyBoss1() :
            base(TextureLibrary.GetTexture("EnemyShip"), new Rectangle(100, 100, 64, 48), 100)
        {
            AccessSpeed = 200;
        }

        float myElapsedTime = 0;
        float myDamage = 25;
        int myDirectionCount = 3;
        float myTotalShootingAngle = 1;
        float myCenterAngle = MathHelper.PiOver2;

        public override void Update(GameTime someTime)
        {
            float tempDeltaTime = (float)someTime.ElapsedGameTime.TotalSeconds;
            myElapsedTime += tempDeltaTime;

            IEnumerable<GameObject> tempPlayers = Game1.myObjects.Where(x => x is Player.Player);
            if (tempPlayers.Count() < 1)
            {
                return;
            }

            Vector2 tempPlayerPosition = tempPlayers.ElementAt(0).AccessRectangle.Location.ToVector2();

            Vector2 tempTargetDirection = Vector2.Normalize(tempPlayerPosition - AccessRectangle.Location.ToVector2());

            Move(someTime, tempTargetDirection);

            if (myElapsedTime >= 0.3)
            {
                myElapsedTime = 0;
                Game1.myObjects.Add(new Bullet(tempTargetDirection, AccessRectangle.Location.ToVector2(), myDamage, 30, this));
                // Shoot();
            }

            if (AcccessHealth <= 0)
            {
                Game1.myObjects.Remove(this);
                (Game1.myObjects.Where(x => x is ScoreUI).First() as ScoreUI).AddScore(1000);
            }
        }

        //private void Shoot()
        //{
        //    float tempAnglePerShot = myTotalShootingAngle / (myDirectionCount - 1);

        //    for (int i = 0; i < myDirectionCount; ++i)
        //    {
        //        float tempAngle = tempAnglePerShot * i + myCenterAngle - myTotalShootingAngle * 0.5f;
        //        Vector2 tempDirection = new Vector2((float)Math.Cos(tempAngle), (float)Math.Sin(tempAngle));
        //        Game1.myObjects.Add(new Bullet(tempDirection, AccessRectangle.Location.ToVector2(), myDamage, 12, this));
        //    }
        //}
    }
}
