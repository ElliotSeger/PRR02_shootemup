﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShootEmUp.Libraries;
using ShootEmUp.Objects;
using ShootEmUp.Objects.Creatures.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUp.UserInterface
{
    class DeathUI : GameObject
    {
        SpriteFont myFont;
        Player myPlayer;

        public DeathUI() :
            base(null, new Rectangle())
        {
            myFont = FontLibrary.GetFont("Font");
            myPlayer = Game1.myObjects.Where(x => x is Player).First() as Player;
        }

        public void Update()
        {

        }
    }
}
