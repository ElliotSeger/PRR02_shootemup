using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using ShootEmUp.Collectibles;
using ShootEmUp.Libraries;
using ShootEmUp.Objects.Creatures;
using ShootEmUp.Objects.Creatures.Enemies;
using ShootEmUp.PowerUps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUp.Objects
{
    class Missile : GameObject
    {
        float myMaxDistance = 2000;
        float myTraveledDistance = 0;
        float myDamage;
        Vector2 myDirection;
        GameObject myShooter;
        float mySpeed;
        BaseEnemy myTarget;

        public Missile(Vector2 aDirection, Vector2 aPosition, float aDamage, float aSpeed, GameObject aShooter) :
            base(TextureLibrary.GetTexture("Missile"), new Rectangle(aPosition.ToPoint(), new Point(100, 100)))
        {
            myDirection = aDirection;
            myDamage = aDamage;
            myShooter = aShooter;
            mySpeed = aSpeed;
            myTarget = (BaseEnemy)Game1.myObjects.Where(x => x is BaseEnemy).FirstOrDefault();
        }

        public override void Update(GameTime someTime)
        {
            Rectangle tempRectangle = AccessRectangle;
            Point tempTravelTransformation = (myDirection * mySpeed).ToPoint();
            tempRectangle.Location += tempTravelTransformation;
            AccessRectangle = tempRectangle;
            myTraveledDistance += tempTravelTransformation.ToVector2().Length();

            if (myTarget != null)
            {
                Vector2 tempTargetDirection = Vector2.Normalize(myTarget.AccessRectangle.Location.ToVector2() - AccessRectangle.Location.ToVector2());
                float tempLerpAmount = 0.1f;
                myDirection = new Vector2(MathHelper.Lerp(myDirection.X, tempTargetDirection.X, tempLerpAmount), MathHelper.Lerp(myDirection.Y, tempTargetDirection.Y, tempLerpAmount));
            }

            AccessRotation = (float)Math.Atan2(myDirection.Y, myDirection.X);

            for (int i = Game1.myObjects.Count - 1; i >= 0; --i)
            {
                GameObject tempCurrentObject = Game1.myObjects[i];

                if (myShooter != tempCurrentObject && tempCurrentObject != this && !(tempCurrentObject is Missile) && tempCurrentObject.AccessRectangle.Intersects(tempRectangle))
                {
                    if (tempCurrentObject is BaseEnemy && myShooter is BaseEnemy)
                    {
                        continue;
                    }

                    if (tempCurrentObject is BaseEnemy)
                    {
                        (tempCurrentObject as BaseEnemy).TakeDamage(25);
                    }

                    if (tempCurrentObject is PowerUp)
                    {
                        continue;
                    }

                    if (tempCurrentObject is Collectible)
                    {
                        continue; // Ignorerar 
                    }

                    if (tempCurrentObject is Bullet)
                    {
                        continue; // Ignorerar kulor.
                    }
                    Game1.myObjects.Remove(this);
                }

                // Förstör missilen efter 2000 längdenheter.

                if (myTraveledDistance > myMaxDistance)
                {
                    Game1.myObjects.Remove(this);
                }
            }
        }
    }
}
