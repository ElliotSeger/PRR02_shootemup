﻿using Microsoft.Xna.Framework;
using ShootEmUp.Libraries;
using ShootEmUp.Objects.Creatures.Player;
using ShootEmUp.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUp.Collectibles
{
    class Coin : Collectible
    {
        public Coin() :
            base(TextureLibrary.GetTexture("Coin"), new Rectangle(750, 100, 40, 40))
        {

        }

        protected override void OnPickup(Player aPlayer)
        {
            Game1.myObjects.Remove(this);
            (Game1.myObjects.Where(x => x is CoinUI).First() as CoinUI).AddCoins(1);
            (Game1.myObjects.Where(x => x is ScoreUI).First() as ScoreUI).AddScore(100);
        }
    }
}
