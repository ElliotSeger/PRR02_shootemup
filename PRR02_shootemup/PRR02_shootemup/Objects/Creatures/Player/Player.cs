using Microsoft.Xna.Framework;
using ShootEmUp.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace ShootEmUp.Objects.Creatures.Player
{
    class Player : Creature
    {
        public Player() :
            base(null, new Rectangle(), 0)
        {
            
        }

        public override void Draw(GameTime someTime, SpriteBatch aSpriteBatch)
        {
        }
    }
}
