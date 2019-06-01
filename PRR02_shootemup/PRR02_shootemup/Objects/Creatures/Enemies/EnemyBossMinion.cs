using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using ShootEmUp.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUp.Objects.Creatures.Enemies
{
    class EnemyBossMinion : BaseEnemy
    {
        float myElapsedTime = 0;
        SoundEffect mySound;
        bool myPlaySound = true;

        public EnemyBossMinion(Point aPosition) :
            base(TextureLibrary.GetTexture("EnemyMinion"), new Rectangle(aPosition.X, aPosition.Y, 40, 30), 20, 10)
        {
            AccessSpeed = 400;
            mySound = SoundLibrary.GetSound("Bee");
        }

        public override void Update(GameTime someTime)
        {
            float tempDeltaTime = (float)someTime.ElapsedGameTime.TotalSeconds;
            myElapsedTime += tempDeltaTime;

            for (int i = Game1.myObjects.Count - 1; i >= 0; --i)
            {
                GameObject tempCurrentObject = Game1.myObjects[i];
                if (tempCurrentObject.AccessRectangle.Intersects(AccessRectangle))
                {
                    // När fienden kolliderar med spelaren förstörs den och spelaren tar 10 poäng i skada.
                    if (tempCurrentObject is Player.Player player)
                    {
                        player.AccessHealth -= 10;
                        Game1.myObjects.Remove(this);
                    }
                }
            }

            IEnumerable<GameObject> tempPlayers = Game1.myObjects.Where(x => x is Player.Player);
            if (tempPlayers.Count() < 1)
            {
                return;
            }

            Vector2 tempPlayerPosition = tempPlayers.ElementAt(0).AccessRectangle.Location.ToVector2();
            Vector2 tempTargetDirection = Vector2.Normalize(tempPlayerPosition - AccessRectangle.Location.ToVector2());

            if (AccessHealth <= 0)
            {
                Game1.myObjects.Remove(this);
            }

            if (myPlaySound == true)
            {
                mySound.Play();
                myPlaySound = false;
            }

            Move(someTime, tempTargetDirection);
        }
    }
}
