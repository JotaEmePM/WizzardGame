using Microsoft.Xna.Framework;

namespace Wizzard.Engine
{
    public class GameConsole : Interfaces.IUpdateable, Interfaces.IDrawable
    {
        private Color color;

        public bool Enabled { get; set; }
        public bool Visible { get; set; }

        public GameConsole(bool enable)
        {
            Enabled = enable;
            Visible = false;
        }

        public void Show()
        {
            Visible = true;
        }

        public void Hide()
        {
            Visible = false;
        }

        public void Draw(GameTime gameTime)
        {
            if (Visible)
            {

            }
        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
