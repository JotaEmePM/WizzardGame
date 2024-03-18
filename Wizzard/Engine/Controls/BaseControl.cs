using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Wizzard.Engine.Controls
{
    public abstract class BaseControl
    {
        public string Text { get; set; }
        public Color Color { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }
        public bool Visible { get; set; }
        public SpriteFont Font { get; set; }

        public abstract void LoadContent();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);
        public abstract void UnloadContent();


    }
}
