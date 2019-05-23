using Microsoft.Xna.Framework;
using ShootEmUp.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUp.Objects.Creatures.Enemies
{
    class EnemyBossMinion : BaseEnemy
    {
        float myElapsedTime = 0;

        public EnemyBossMinion(Point aPosition) :
            base(TextureLibrary.GetTexture("EnemyShip"), new Rectangle(aPosition.X, aPosition.Y, 32, 24))
        {

        }

        public override void Update(GameTime someTime)
        {
            float tempDeltaTime = (float)someTime.ElapsedGameTime.TotalSeconds;
            myElapsedTime += tempDeltaTime;

            for (int i = Game1.myObjects.Count - 1; i >= 0; --i)
            {
                GameObject tempCurrentObject = Game1.myObjects[i];
                if (tempCurrentObject.AccessRectangle.Intersects(AccessRectangle))
                {
                    if (tempCurrentObject is Player.Player player)
                    {
                        player.AcccessHealth -= (float)someTime.ElapsedGameTime.TotalSeconds * 10; 
                    }
                }
            }

            IEnumerable<GameObject> tempPlayers = Game1.myObjects.Where(x => x is Player.Player);
            if (tempPlayers.Count() < 1)
            {
                return;
            }
            Vector2 tempPlayerPosition = tempPlayers.ElementAt(0).AccessRectangle.Location.ToVector2();

            Vector2 tempTargetDirection = Vector2.Normalize(tempPlayerPosition - AccessRectangle.Location.ToVector2());

            base.Update(someTime);

            Move(someTime, tempTargetDirection);
        }
    }
}
