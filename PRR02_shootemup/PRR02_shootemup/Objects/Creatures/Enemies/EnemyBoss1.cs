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
        float myElapsedTime = 0;
        float myElapsedSpawnTime = 0;

        public EnemyBoss1(Point aPosition) :
            base(TextureLibrary.GetTexture("EnemyShip"), new Rectangle(aPosition.X, aPosition.Y, 128, 96), 250, 1000)
        {
            AccessSpeed = 200;
        }

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
