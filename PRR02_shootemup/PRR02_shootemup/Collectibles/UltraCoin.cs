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
    class UltraCoin : Collectible
    {
        public UltraCoin() :
            base(TextureLibrary.GetTexture(""), new Rectangle())
        {

        }

        protected override void OnPickup(PlayerSoldier aPlayer)
        {
            
            Game1.myObjects.Remove(this);
        }
    }
}
