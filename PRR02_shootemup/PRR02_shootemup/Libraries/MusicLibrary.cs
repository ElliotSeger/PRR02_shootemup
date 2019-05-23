using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUp.Libraries
{
    class MusicLibrary
    {
        static Dictionary<string, Song> myMusic;

        public static Song GetMusic(string aKey)
        {
            return myMusic[aKey];
        }

        public static void LoadTextures(ContentManager someContent)
        {
            myMusic = new Dictionary<string, Song>
            {
                
            };
        }
    }
}
