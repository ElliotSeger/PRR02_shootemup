using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace ShootEmUp.Libraries
{
    static class TextureLibrary
    {
        static Dictionary<string, Texture2D> myTextures;

        public static Texture2D GetTexture(string aKey)
        {
            return myTextures[aKey];
        }

        public static void LoadTextures(ContentManager someContent)
        {
            myTextures = new Dictionary<string, Texture2D>
            {
                ["Player"] = someContent.Load<Texture2D>("player"),
                ["Ship"] = someContent.Load<Texture2D>("ship"),
                ["EnemyShip"] = someContent.Load<Texture2D>("enemy"),
                ["Bullet"] = someContent.Load<Texture2D>("bullet"),
                ["HealthPowerUp"] = someContent.Load<Texture2D>("powerup_health"),
                ["SpeedPowerUp"] = someContent.Load<Texture2D>("powerup_speed"),
                ["Coin"] = someContent.Load<Texture2D>("coin"),
                ["Orb"] = someContent.Load<Texture2D>("orb"),
                // ["CargoShip"] = someContent.Load<Texture2D>("cargo_ship"),
            };
        }
    }
}
