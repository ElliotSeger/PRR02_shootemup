using Microsoft.Xna.Framework;
using ShootEmUp.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUp.Objects.Creatures.Enemies
{
    class EnemyBoss2 : BaseEnemy
    {
        float myElapsedTime = 0;
        float myDamage = 10;

        public EnemyBoss2(Point aPosition) :
            base(TextureLibrary.GetTexture("EnemyShip"), new Rectangle(aPosition.X, aPosition.Y, 128, 96), 250, 1000)
        {
            AccessSpeed = 100;
        }

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
            }

            Move(someTime, tempTargetDirection);

            base.Update(someTime);
        }
    }
}
