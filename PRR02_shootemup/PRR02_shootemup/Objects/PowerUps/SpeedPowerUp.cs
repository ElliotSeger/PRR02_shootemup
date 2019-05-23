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
        public SpeedPowerUp(Point aPosition) :
            base(TextureLibrary.GetTexture("SpeedPowerUp"), new Rectangle(aPosition.X, aPosition.Y, 100, 100))
        {

        }

        protected override void OnPickup(Player aShip)
        {
            
            Game1.myObjects.Remove(this);
        }
    }
}
