using Microsoft.Xna.Framework;
using Wizzard.Engine;
using Wizzard.Engine.Controls;

namespace Wizzard.Scenes
{
    public class MenuScene : Scene
    {
        Label GameNameLabel;

        public MenuScene(string name) : base(name)
        {
            this.Name = name;

            GameNameLabel = new Label("Hello world", new Vector2(200, 200), Globals.BaseSpriteFont, Color.White);

            this.UnitManager = new UnitManager();
            this.UnitManager.Add(GameNameLabel);
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gametime)
        {
            base.Update(gametime);
        }

        public override void Draw(GameTime gameTime)
        {


            base.Draw(gameTime);
        }

    }
}
