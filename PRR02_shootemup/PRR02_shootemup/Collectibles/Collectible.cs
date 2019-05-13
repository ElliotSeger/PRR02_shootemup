using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShootEmUp.Libraries;
using ShootEmUp.Objects;
using ShootEmUp.Objects.Creatures.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUp.Collectibles
{
    class Collectible : GameObject
    {
        public Collectible(Texture2D aTexture, Rectangle aRectangle, float aRotation = 0) :
            base(aTexture, aRectangle, aRotation)
        {

        }

        public override void Update(GameTime someTime)
        {
            for (int i = Game1.myObjects.Count - 1; i >= 0; --i)
            {
                GameObject tempCurrentObject = Game1.myObjects[i];
                if (tempCurrentObject is PlayerSoldier tempPlayer && tempCurrentObject.AccessRectangle.Intersects(AccessRectangle))
                    OnPickup(tempPlayer);
            }
        }

        protected virtual void OnPickup(PlayerSoldier aPlayer)
        {

        }
    }
}
