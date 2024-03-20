using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Wizzard.Engine
{
    public class GameConsole : Interfaces.IUpdateable, Interfaces.IDrawable
    {
        private Color color;
        private Texture2D rectangle;

        private static GameConsole instance;

        private List<string> lines = new();


        public bool Enabled { get; set; }
        public bool Visible { get; set; }

        public GameConsole(bool enable)
        {
            if (instance == null)
            {
                instance = this;

                Enabled = enable;
                Visible = false;
            }
        }

        public void Load()
        {
            rectangle = new Texture2D(Globals.Globals.GraphicsDevice, 1, 1);
            rectangle.SetData(new[] { Color.White });
        }

        public void Show()
        {
            Visible = true;
        }

        public void Hide()
        {
            Visible = false;
        }

        public void Toggle()
        {
            Visible = !Visible;
        }


        public void Draw(GameTime gameTime)
        {
            if (Visible)
            {
                // Draw a gray rectangle
                Globals.Globals.SpriteBatch.Draw(rectangle, new Rectangle(10, 20,
                    Globals.Globals.GraphicsDevice.Viewport.Width - 20, 200),
                    Color.Gray * 0.5f);
            }
        }

        public void Update(GameTime gameTime)
        {

        }

        public static GameConsole GetInstance()
        {
            return instance;
        }

        public static void WriteLine(string text)
        {
            if (instance != null)
            {
                instance.lines.Add(text);
            }
        }
    }
}
