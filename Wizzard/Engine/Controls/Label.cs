using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Wizzard.Engine.Controls
{
    internal class Label : BaseControl
    {
        public Label(string text, Vector2 position, SpriteFont font, Color color)
        {
            this.Text = text;
            this.Position = position;
            this.Font = font;
            this.Color = color;

            this.Visible = true;
        }

        public override void Draw(GameTime gameTime)
        {
            if (this.Visible && !string.IsNullOrEmpty(this.Text))
                Globals.Globals.SpriteBatch.DrawString(Font, Text, Position, Color);
        }

        public override void LoadContent()
        {

        }

        public override void UnloadContent() { }

        public override void Update(GameTime gameTime) { }
    }
}
