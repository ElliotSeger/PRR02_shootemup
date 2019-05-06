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
    class SpeedPowerUp : PowerUp
    {
        public SpeedPowerUp() :
            base(TextureLibrary.GetTexture("SpeedPowerUp"), new Rectangle(400, 400, 100, 100))
        {

        }

        protected override void OnPickup(PlayerShip aShip)
        {
            aShip.GiveSpeed(100);
            Game1.myObjects.Remove(this);
        }
    }
}
