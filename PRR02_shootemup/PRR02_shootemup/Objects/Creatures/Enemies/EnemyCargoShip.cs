using Microsoft.Xna.Framework;
using ShootEmUp.Collectibles;
using ShootEmUp.Libraries;
using ShootEmUp.Objects.PowerUps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUp.Objects.Creatures.Enemies
{
    class EnemyCargoShip : BaseEnemy
    {
        Random myRandom = new Random();

        public EnemyCargoShip(Point aPosition) :
            base(TextureLibrary.GetTexture("CargoShip"), new Rectangle(aPosition.X, aPosition.Y, 64, 48), 50)
        {
            AccessSpeed = 200;
        }

        public override void Update(GameTime someTime)
        {
            if (AccessHealth <= 0)
            {
                double tempValue = myRandom.NextDouble();

                if (tempValue < 0.8)
                {
                    Game1.myObjects.Add(new GoldCoin(AccessPosition.ToPoint()));
                }

                if (tempValue < 0.4)
                {
                    Game1.myObjects.Add(new PlatinumCoin(AccessPosition.ToPoint()));
                }

                if (tempValue < 0.7)
                {
                    Game1.myObjects.Add(new HealthPowerUp(AccessPosition.ToPoint()));
                }

                Game1.myObjects.Remove(this);
            }

            Move(someTime, Vector2.UnitY);
        }
    }
}
