using Microsoft.Xna.Framework;
using ShootEmUp.Libraries;
using ShootEmUp.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUp.GameStates
{
    class GameState : GameObject
    {
        public GameState() :
            base(null, new Rectangle())
        {
            
        }

        enum GameStates
        {
            StartMenu,
            Loading,
            Playing,
            Paused
        }
    }
}
