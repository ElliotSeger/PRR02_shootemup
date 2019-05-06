﻿using ShootEmUp.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using ShootEmUp.Objects.Creatures;
using ShootEmUp.PowerUps;

namespace ShootEmUp.Objects
{
    class Bullet : GameObject
    {
        float myMaxDistance = 1750;
        float myTraveledDistance = 0;
        float mySpeed = 15;
        float myDamage;
        Vector2 myDirection;
        GameObject myShooter;

        public Bullet(Vector2 aDirection, Vector2 aPosition, float aDamage, GameObject aShooter) :
            base(TextureLibrary.GetTexture("Bullet"), new Rectangle(aPosition.ToPoint(), new Point(50, 50)))
        {
            myDirection = aDirection;
            myDamage = aDamage;
            myShooter = aShooter;
        }

        public override void Update(GameTime someTime)
        {
            Rectangle tempRectangle = AccessRectangle;
            Point travelTransformation = (myDirection * mySpeed).ToPoint();
            tempRectangle.Location += travelTransformation;
            AccessRectangle = tempRectangle;
            myTraveledDistance += travelTransformation.ToVector2().Length();

            for (int i = Game1.myObjects.Count - 1; i >= 0; --i)
            {
                GameObject tempCurrentObject = Game1.myObjects[i];
                if (myShooter != tempCurrentObject && tempCurrentObject != this && !(tempCurrentObject is Bullet) && tempCurrentObject.AccessRectangle.Intersects(tempRectangle))
                {
                    if (tempCurrentObject is Creature)
                    {
                        (tempCurrentObject as Creature).TakeDamage(10);
                    }

                    if (tempCurrentObject is PowerUp)
                    {
                        continue;
                    }
                    Game1.myObjects.Remove(this);
                }
            }

            // Förstör kulan efter 1750 längdenheter.

            if (myTraveledDistance > myMaxDistance)
            {
                Game1.myObjects.Remove(this);
            }
        }
    }
}