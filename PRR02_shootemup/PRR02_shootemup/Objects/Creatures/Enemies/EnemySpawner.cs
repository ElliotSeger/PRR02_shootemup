using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUp.Objects.Creatures.Enemies
{
    class EnemySpawner
    {
        List<(float, BaseEnemy)> myEnemySpawnQueue;
        float myTimeSinceLastSpawn;

        public void Update(GameTime someTime)
        {
            myTimeSinceLastSpawn += (float)someTime.ElapsedGameTime.TotalSeconds;

            if (myEnemySpawnQueue.Count > 0 && myTimeSinceLastSpawn >= myEnemySpawnQueue[0].Item1)
            {
                Game1.myObjects.Add(myEnemySpawnQueue[0].Item2);
                myEnemySpawnQueue.RemoveAt(0);
                myTimeSinceLastSpawn = 0;
            }
        }

        public EnemySpawner(params (float, BaseEnemy)[] someEnemies)
        {
            myEnemySpawnQueue = new List<(float, BaseEnemy)>(someEnemies);
        }
    }
}
