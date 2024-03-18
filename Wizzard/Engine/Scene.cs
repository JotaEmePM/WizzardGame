using Microsoft.Xna.Framework;

namespace Wizzard.Engine
{
    public class Scene
    {
        public string Name { get; set; } = "SCENE";

        public UnitManager UnitManager;

        public Scene(string name)
        {
            Name = name;
            UnitManager = new();
        }

        public virtual void LoadContent()
        {
            UnitManager.Load();
        }

        public virtual void UnloadContent()
        {
            UnitManager.Unload();
        }


        public virtual void Update(GameTime gametime)
        {
            UnitManager.Update(gametime);
        }

        public virtual void Draw(GameTime gameTime)
        {
            UnitManager.Draw(gameTime);
        }
    }
}
