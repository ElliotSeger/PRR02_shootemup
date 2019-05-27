using ShootEmUp.Libraries;
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
using ShootEmUp.Objects.Creatures.Enemies;
using ShootEmUp.Collectibles;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace ShootEmUp.Objects
{
    class Bullet : GameObject
    {
        float myMaxDistance = 2000;
        float myTraveledDistance = 0;
        float myDamage;
        Vector2 myDirection;
        GameObject myShooter;
        float mySpeed;
        SoundEffect mySong;
        bool myPlay = true;

        public Bullet(Vector2 aDirection, Vector2 aPosition, float aDamage, float aSpeed, GameObject aShooter) :
            base(TextureLibrary.GetTexture("Bullet"), new Rectangle(aPosition.ToPoint(), new Point(25, 25)))
        {
            myDirection = aDirection;
            myDamage = aDamage;
            myShooter = aShooter;
            mySpeed = aSpeed;
            mySong = SoundLibrary.GetMusic("Shoot");
        }

        public override void Update(GameTime someTime)
        {
            Rectangle tempRectangle = AccessRectangle;
            Point tempTravelTransformation = (myDirection * mySpeed).ToPoint();
            tempRectangle.Location += tempTravelTransformation;
            AccessRectangle = tempRectangle;
            myTraveledDistance += tempTravelTransformation.ToVector2().Length();

            for (int i = Game1.myObjects.Count - 1; i >= 0; --i)
            {
                GameObject tempCurrentObject = Game1.myObjects[i];
                if (myShooter != tempCurrentObject && tempCurrentObject != this && !(tempCurrentObject is Bullet) && tempCurrentObject.AccessRectangle.Intersects(tempRectangle))
                {
                    if (tempCurrentObject is BaseEnemy && myShooter is BaseEnemy)
                    {
                        continue; // Kulan ignorerar fiender om myShooter är BaseEnemy.
                    }

                    if (tempCurrentObject is Creature)
                    {
                        (tempCurrentObject as Creature).TakeDamage(10);
                    }

                    if (tempCurrentObject is PowerUp)
                    {
                        continue; // Kulan ignorerar PowerUps.
                    }

                    if (tempCurrentObject is Collectible)
                    {
                        continue; // Kulan ignorerar Collectibles.
                    }

                    if (tempCurrentObject is Missile)
                    {
                        continue; // Kulan ignorerar missiler.
                    }

                    Game1.myObjects.Remove(this);
                }

                if (myPlay == true) // Ljudfilen spelas enbart en gång när kulan skapas. 
                {
                    mySong.Play();
                    myPlay = false;
                }
            }

            if (myTraveledDistance > myMaxDistance) // Om kulans distans är mer än 2000 förstörs den.
            {
                Game1.myObjects.Remove(this);
            }
        }
    }
}
