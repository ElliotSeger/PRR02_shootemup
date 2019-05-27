using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShootEmUp.Collectibles;
using ShootEmUp.Objects.PowerUps;
using ShootEmUp.PowerUps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUp.Objects.Creatures.Enemies
{
    public class BaseEnemy : Creature
    {
        static Random myRandom = new Random();
        int myScore;

        public BaseEnemy(Texture2D aTexture, Rectangle aRectangle, float aHealth = 0, int aScore = 0) :
            base(aTexture, aRectangle, aHealth)
        {
            myScore = aScore;
        }

        public override void Update(GameTime someTime)
        {
            if (AccessHealth <= 0)
            {
                double tempValue = myRandom.NextDouble();

                if (tempValue < 0.4) // 40 % chans att en fiende släpper ett guldmynt.
                {
                    Game1.myObjects.Add(new GoldCoin(AccessPosition.ToPoint()));
                }

                else if (tempValue < 0.6) // 20 % chans att en fiende släpper en hälso-powerup.
                {
                    Game1.myObjects.Add(new HealthPowerUp(AccessPosition.ToPoint()));
                }

                else if (tempValue < 0.8) // 20 % chans att en fiende släpper ett platinamynt.
                {
                    Game1.myObjects.Add(new PlatinumCoin(AccessPosition.ToPoint()));
                }

                Game1.myObjects.Remove(this);
                (Game1.myObjects.Where(x => x is ScoreUI).First() as ScoreUI).AddScore(myScore);
                
            }
        }

        // Move-metoden gör att fienderna flyttar på sig på olika sätt. 

        public void Move(GameTime someTime, Vector2 aDirection)
        {
            AccessPosition += aDirection * (float)someTime.ElapsedGameTime.TotalSeconds * AccessSpeed;
        }
    }
}
