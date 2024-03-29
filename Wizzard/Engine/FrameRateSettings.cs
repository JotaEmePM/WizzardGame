﻿namespace Wizzard.Engine
{
    /// <summary>
    /// Settings regarding timesteps.
    /// </summary>
    public enum TimestepSettings
    {
        /// <summary>
        /// The game will run at a fixed interval to hit the target framerate.
        /// </summary>
        Fixed,

        /// <summary>
        /// The game will run at a variable interval and run as fast as allowed by the graphics card.
        /// </summary>
        Variable
    }

    /// <summary>
    /// Settings regarding VSync.
    /// </summary>
    public enum VSyncSettings
    {
        Enabled, Disabled
    }
}
