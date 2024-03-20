using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Wizzard.Engine;
using Wizzard.Engine.Globals;
using Wizzard.Scenes;

namespace Wizzard
{
    public class Main : Game
    {
        public bool DebugMode { get; set; }

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        SceneManager _sceneManager;
        private GameConsole console;

        public Main(Boolean debugMode)
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _sceneManager = new SceneManager();

            this.DebugMode = debugMode;
            
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();

            Globals.ContentManager = Content;
            Globals.SpriteBatch = _spriteBatch;
            Globals.SceneManager = _sceneManager;
            Globals.GraphicsDevice = this.GraphicsDevice;

            _sceneManager.SceneList.Add(new MenuScene("MENU"));
            _sceneManager.ChangeScene("MENU");
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Globals.BaseSpriteFont = Content.Load<SpriteFont>("Fonts/Madimi One");

            _sceneManager.Load();

            if (DebugMode)
            {
                Globals.GraphicsDevice = this.GraphicsDevice;
                console = new GameConsole(true);
                console.Load();

            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.F1) && DebugMode)
                console.Toggle();





            _sceneManager.Update(gameTime);
            // TODO: Add your update logic here


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Globals.SpriteBatch.Begin();

            _sceneManager.Draw(gameTime);
            console.Draw(gameTime);
            base.Draw(gameTime);
            Globals.SpriteBatch.End();
        }
    }
}
