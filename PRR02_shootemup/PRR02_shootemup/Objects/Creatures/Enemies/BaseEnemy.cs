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
            if (AcccessHealth <= 0)
            {
                Game1.myObjects.Remove(this);
                (Game1.myObjects.Where(x => x is ScoreUI).First() as ScoreUI).AddScore(myScore);

                double tempValue = myRandom.NextDouble();

                if (tempValue < 0.4) // 40 % chans.
                {
                    Game1.myObjects.Add(new Coin());
                }

                else if (tempValue < 0.6) // 20 % chans.
                {
                    Game1.myObjects.Add(new HealthPowerUp());
                }

                else if (tempValue < 0.65) // 5 % chans.
                {
                    Game1.myObjects.Add(new UltraCoin());
                }
            }
        }

        // Move-metoden gör att fienderna flyttar på sig på olika sätt. 

        public void Move(GameTime someTime, Vector2 aDirection)
        {
            AccessPosition += aDirection * (float)someTime.ElapsedGameTime.TotalSeconds * AccessSpeed;
        }
    }
}
