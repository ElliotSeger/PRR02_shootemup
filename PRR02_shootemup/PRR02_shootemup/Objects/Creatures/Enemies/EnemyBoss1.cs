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
            base(TextureLibrary.GetTexture("EnemyShip"), new Rectangle(100, 100, 128, 96), 125, 1000)
        {
            AccessSpeed = 200;
        }

        float myElapsedTime = 0;
        float myElapsedSpawnTime = 0;
        float myDamage = 25;
        int myDirectionCount = 3;
        float myTotalShootingAngle = 1;
        float myCenterAngle = MathHelper.PiOver2;

        public override void Update(GameTime someTime)
        {
            float tempDeltaTime = (float)someTime.ElapsedGameTime.TotalSeconds;
            myElapsedTime += tempDeltaTime;
            myElapsedSpawnTime += tempDeltaTime;

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
            }

            if (myElapsedSpawnTime >= 3)
            {
                myElapsedSpawnTime = 0;
                Game1.myObjects.Add(new EnemyBossMinion(AccessPosition.ToPoint()));
            }

            if (AccessHealth <= 0)
            {
                Game1.myObjects.Remove(this);
                (Game1.myObjects.Where(x => x is ScoreUI).First() as ScoreUI).AddScore(1000);

                Game1.myIsShowingUpgradeMenu = true;
                Game1.NextLevel();
            }
        }
    }
}
