using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using ShootEmUp.Objects;
using ShootEmUp.Libraries;

namespace ShootEmUp
{
    class ScoreUI : GameObject
    {
        SpriteFont myFont;
        int myScore;

        public ScoreUI() :
            base(null, new Rectangle())
        {
            myFont = FontLibrary.GetFont("Font");
        }

        public void AddScore(int aScore)
        {
            myScore += aScore;
        }

        public override void Draw(GameTime someTime, SpriteBatch aSpriteBatch)
        {
           aSpriteBatch.DrawString(myFont, $"Score {myScore}", new Vector2(50, 50), Color.White);
        }
    }
}
