using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUp.Libraries
{
    class SoundLibrary
    {
        static Dictionary<string, SoundEffect> mySound;

        public static SoundEffect GetSound(string aKey)
        {
            return mySound[aKey];
        }

        public static void LoadSound(ContentManager someContent)
        {
            mySound = new Dictionary<string, SoundEffect>
            {
                ["Shoot"] = someContent.Load<SoundEffect>("shoot"),
                ["Bee"] = someContent.Load<SoundEffect>("bee"),
            };
        }
    }
}
