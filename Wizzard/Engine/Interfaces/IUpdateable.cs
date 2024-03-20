using Microsoft.Xna.Framework;

namespace Wizzard.Engine.Interfaces
{
    /// <summary>
    /// An interface for objects that update.
    /// </summary>
    public interface IUpdateable
    {
        /// <summary>
        /// Performs update logic.
        /// </summary>
        void Update(GameTime gameTime);
    }
}
