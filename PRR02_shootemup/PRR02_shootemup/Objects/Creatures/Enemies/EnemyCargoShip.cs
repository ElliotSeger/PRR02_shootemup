using Microsoft.Xna.Framework;
using ShootEmUp.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUp.Objects.Creatures.Enemies
{
    class EnemyCargoShip : BaseEnemy
    {
        public EnemyCargoShip() :
            base(TextureLibrary.GetTexture("CargoShip"), new Rectangle(500, 500, 64, 48), 50)
        {

        }

        public override void Update(GameTime someTime)
        {
            Move(someTime, Vector2.UnitY);
        }
    }
}
