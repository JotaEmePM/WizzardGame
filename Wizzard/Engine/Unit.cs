using Microsoft.Xna.Framework;

namespace Wizzard.Engine
{
    public abstract class Unit
    {
        public Unit()
        {

        }

        public abstract void LoadContent();
        public abstract void UnloadContent();
        public abstract void Update(GameTime gametime);
        public abstract void Draw(GameTime gameTime);
    }
}
