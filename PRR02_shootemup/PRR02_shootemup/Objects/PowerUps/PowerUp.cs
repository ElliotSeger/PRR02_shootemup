using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using ShootEmUp.Objects;
using ShootEmUp.Libraries;
using ShootEmUp.Objects.Creatures.Player;

namespace ShootEmUp.PowerUps
{
    public class PowerUp : GameObject
    {
        public PowerUp(Texture2D aTexture, Rectangle aRectangle, float aRotation = 0) :
            base(aTexture, aRectangle, aRotation)
        {

        }

        public override void Update (GameTime someTime)
        {
            for (int i = Game1.myObjects.Count - 1; i >= 0; --i)
            {
                GameObject tempCurrentObject = Game1.myObjects[i];
                if (tempCurrentObject is PlayerShip tempShip && tempCurrentObject.AccessRectangle.Intersects(AccessRectangle))
                {
                    OnPickup(tempShip);
                }
            }
        }

        protected virtual void OnPickup(PlayerShip aShip)
        {

        }
    }
}
