using Microsoft.Xna.Framework;
using ShootEmUp.Libraries;
using ShootEmUp.Objects.Creatures.Player;
using ShootEmUp.PowerUps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUp.Objects.PowerUps
{
    class HealthPowerUp : PowerUp
    {
        public HealthPowerUp() :
            base(TextureLibrary.GetTexture("HealthPowerUp"), new Rectangle(500, 500, 100, 100))
        {

        }

        protected override void OnPickup(Player aShip)
        {
            aShip.GiveHealth(10);
            Game1.myObjects.Remove(this);
        }
    }
}
