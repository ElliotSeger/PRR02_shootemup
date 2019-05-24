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
        public float AccessHealth { get; set; }
        public float AccessSpeed { get; set; }

        public Creature(Texture2D aTexture, Rectangle aRectangle, float aHealth, float aRotation = 0) :
            base(aTexture, aRectangle, aRotation)
        {
            AccessHealth = aHealth;
        }

        public void TakeDamage(float someDamage)
        {
            AccessHealth -= someDamage;
        }

        public void GiveHealth(float someHealth)
        {
            AccessHealth += someHealth;
        }

        public void GiveSpeed(float someSpeed)
        {
            AccessSpeed += someSpeed;
        }

        public override void Update(GameTime someTime)
        {
            if (AccessHealth <= 0)
            {
                Game1.myObjects.Remove(this);
            }
        }
    }
}
