using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Wizzard.Engine
{
    public class SceneManager
    {
        public List<Scene> SceneList { get; } = new();
        private Scene currentScene;

        public void AddScene(Scene scene)
        {
            SceneList.Add(scene);
        }

        public void ChangeScene(string sceneName)
        {
            Scene newScene = SceneList.Find(s => s.Name == sceneName);

            if (newScene != null)
            {
                currentScene?.UnloadContent();

                currentScene = newScene;
                currentScene.LoadContent();
            }
        }

        public void Load()
        {
            currentScene?.LoadContent();
        }

        public void Update(GameTime gametime)
        {
            currentScene?.Update(gametime);
        }

        public void Draw(GameTime gameTime)
        {
            currentScene?.Draw(gameTime);
        }
    }
}
