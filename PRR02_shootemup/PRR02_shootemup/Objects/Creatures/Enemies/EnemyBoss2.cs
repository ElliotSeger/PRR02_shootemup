using Microsoft.Xna.Framework;
using ShootEmUp.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUp.Objects.Creatures.Enemies
{
    class EnemyBoss2 : BaseEnemy
    {
        public EnemyBoss2() :
            base(TextureLibrary.GetTexture("EnemyShip"), new Rectangle())
        {

        }
    }
}
