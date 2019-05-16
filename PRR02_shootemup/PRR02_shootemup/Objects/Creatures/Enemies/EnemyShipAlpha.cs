using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShootEmUp.Libraries;
using ShootEmUp.Objects.Creatures.Enemies;

namespace ShootEmUp.Objects.Creatures
{
    public class EnemyShipAlpha : BaseEnemy
    {
        public EnemyShipAlpha() :
            base(TextureLibrary.GetTexture("EnemyShip"), new Rectangle(50, 50, 64, 48), 10)
        {

        }

        float myElapsedTime = 0;
        float myDamage = 10;

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

            if (myElapsedTime >= 0.5f)
            {
                myElapsedTime = 0;
                Game1.myObjects.Add(new Bullet(tempTargetDirection, AccessRectangle.Location.ToVector2(), myDamage, 15, this));
            }

            if (AcccessHealth <= 0)
            {
                Game1.myObjects.Remove(this);
                (Game1.myObjects.Where(x => x is ScoreUI).First() as ScoreUI).AddScore(100);
            }
        }
    }
}
