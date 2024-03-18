using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Wizzard.Engine
{
    public static class Globals
    {
        public static string GAME_NAME = "WIZZARD";
        public static string GAME_VERSION = "0.1";
        public static string WEB_URL = "";
        public static string BRAND = "";

        public static List<(int, int)> RESOLUTIONS = new List<(int, int)>()
        {
            (800, 600),
            (1024,768),
            (1920, 1080)
        };


        public static SpriteBatch SpriteBatch;
        public static ContentManager ContentManager;
        public static SceneManager SceneManager;

        public static SpriteFont BaseSpriteFont;



    }
}
