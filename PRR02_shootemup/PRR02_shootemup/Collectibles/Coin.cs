using Microsoft.Xna.Framework;
using ShootEmUp.Libraries;
using ShootEmUp.Objects.Creatures.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUp.Collectibles
{
    class Coin : Collectible
    {
        public Coin() :
            base(TextureLibrary.GetTexture("Coin"), new Rectangle(750, 100, 64, 64))
        {

        }

        protected override void OnPickup(Player aPlayer)
        {
            Game1.myObjects.Remove(this);
        }
    }
}
