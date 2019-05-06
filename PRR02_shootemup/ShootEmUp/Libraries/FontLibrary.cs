using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUp.Libraries
{
    static class FontLibrary
    {
        static Dictionary<string, SpriteFont> myFonts;

        public static SpriteFont GetFont(string aKey)
        {
            return myFonts[aKey];
        }

        public static void LoadFont(ContentManager someContent)
        {
            myFonts = new Dictionary<string, SpriteFont>
            {
                ["Font"] = someContent.Load<SpriteFont>("font"),
            };
        }
    }
}
