using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Wizzard.Engine;
using Wizzard.Scenes;

namespace Wizzard
{
    public class Main : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        SceneManager _sceneManager;

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _sceneManager = new SceneManager();




        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();

            Globals.ContentManager = Content;
            Globals.SpriteBatch = _spriteBatch;
            Globals.SceneManager = _sceneManager;

            _sceneManager.SceneList.Add(new MenuScene("MENU"));
            _sceneManager.ChangeScene("MENU");
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Globals.BaseSpriteFont = Content.Load<SpriteFont>("Fonts/Madimi One");

            _sceneManager.Load();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _sceneManager.Update(gameTime);
            // TODO: Add your update logic here


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Globals.SpriteBatch.Begin();

            _sceneManager.Draw(gameTime);

            base.Draw(gameTime);
            Globals.SpriteBatch.End();
        }
    }
}
