using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUp.Objects
{
    public class GameObject
    {
        protected Texture2D AccessTexture { get; set; }
        public Rectangle AccessRectangle { get; set; }
        protected float AccessRotation { get; set; }

        private Vector2 myPosition;
        protected Vector2 AccessPosition
        {
            get => myPosition;
            set
            {
                myPosition = value;
                Rectangle tempRectangle = AccessRectangle;
                tempRectangle.Location = value.ToPoint();
                AccessRectangle = tempRectangle;
            }
        }

        public GameObject(Texture2D aTexture, Rectangle aRectangle, float aRotation = 0)
        {
            AccessTexture = aTexture;
            AccessRectangle = aRectangle;
            AccessPosition = aRectangle.Location.ToVector2();
            AccessRotation = aRotation;
        }

        public virtual void Update(GameTime someTime) { }

        public virtual void Draw(GameTime someTime, SpriteBatch aSpriteBatch)
        {
            aSpriteBatch.Draw(AccessTexture, AccessRectangle, null, Color.White, AccessRotation, AccessTexture.Bounds.Size.ToVector2() * 0.5f, SpriteEffects.None, 0);
        }
    }
}
