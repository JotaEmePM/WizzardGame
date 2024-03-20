using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Wizzard.Engine
{
    public class GameConsole : Interfaces.IUpdateable, Interfaces.IDrawable
    {
        private Color color;
        private Texture2D rectangle;

        public bool Enabled { get; set; }
        public bool Visible { get; set; }

        public GameConsole(bool enable)
        {
            Enabled = enable;
            Visible = false;

            
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
                Globals.Globals.SpriteBatch.Draw(rectangle, new Rectangle(10, 20, 80, 30), Color.Chocolate);
            }
        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
