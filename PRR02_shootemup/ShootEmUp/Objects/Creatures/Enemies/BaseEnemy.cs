using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUp.Objects.Creatures.Enemies
{
    public class BaseEnemy : Creature
    {
        public BaseEnemy(Texture2D aTexture, Rectangle aRectangle, float aRotation = 0) :
            base(aTexture, aRectangle, aRotation)
        {

        }

        public override void Update(GameTime someTime)
        {
        }
    }
}
