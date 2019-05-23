using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUp.Objects.Creatures
{
    public class Creature : GameObject
    {
        public float AcccessHealth { get; set; }
        public float AccessSpeed { get; set; }

        public Creature(Texture2D aTexture, Rectangle aRectangle, float aHealth, float aRotation = 0) :
            base(aTexture, aRectangle, aRotation)
        {
            AcccessHealth = aHealth;
        }

        public void TakeDamage(float someDamage)
        {
            AcccessHealth -= someDamage;
        }

        public void GiveHealth(float someHealth)
        {
            AcccessHealth += someHealth;
        }

        public void GiveSpeed(float someSpeed)
        {
            AccessSpeed += someSpeed;
        }

        public override void Update(GameTime someTime)
        {
            if (AcccessHealth <= 0)
            {
                Game1.myObjects.Remove(this);
            }
        }
    }
}
