using Microsoft.Xna.Framework;
using Wizzard.Engine;
using Wizzard.Engine.Controls;
using Wizzard.Engine.Globals;
using Wizzard.Engine.Player;

namespace Wizzard.Scenes
{
    public class MenuScene : Scene
    {
        Label GameNameLabel;
        Player player;

        public MenuScene(string name) : base(name)
        {
            this.Name = name;

            GameNameLabel = new Label("Hello world", new Vector2(200, 200), Globals.BaseSpriteFont, Color.White);


            player = new Player("TEST_PLAYER", Job.Archer);

            this.UnitManager = new UnitManager();
            this.UnitManager.Add(GameNameLabel);
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gametime)
        {
            player.Update(gametime);
            base.Update(gametime);
        }

        public override void Draw(GameTime gameTime)
        {
            player.Draw(gameTime);

            base.Draw(gameTime);
        }

    }
}
