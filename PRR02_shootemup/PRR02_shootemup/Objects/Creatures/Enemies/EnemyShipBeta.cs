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

        }

        float myElapsedTime = 0;
        float myDamage = 10;

        public override void Update(GameTime someTime)
        {
            float tempDeltaTime = (float)someTime.ElapsedGameTime.TotalSeconds;
            myElapsedTime += tempDeltaTime;

            if (myElapsedTime >= 0.3f)
            {
                myElapsedTime = 0;
                Game1.myObjects.Add(new Bullet(Vector2.UnitY, AccessRectangle.Location.ToVector2(), myDamage, this));
                Game1.myObjects.Add(new Bullet());
                Game1.myObjects.Add(new Bullet());
            }

            if (AcccessHealth <= 0)
            {
                Game1.myObjects.Remove(this);
                (Game1.myObjects.Where(x => x is ScoreUI).First() as ScoreUI).AddScore(100);
            }
        }
    }
}
