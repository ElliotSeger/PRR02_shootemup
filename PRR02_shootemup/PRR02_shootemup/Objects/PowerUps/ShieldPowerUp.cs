using Microsoft.Xna.Framework;
using ShootEmUp.Libraries;
using ShootEmUp.PowerUps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUp.Objects.PowerUps
{
    class ShieldPowerUp : PowerUp
    {
        public ShieldPowerUp() :
            base(TextureLibrary.GetTexture("EnemyShip"), new Rectangle(750, 750, 100, 100))
        {

        }
    }
}
