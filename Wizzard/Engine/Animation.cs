using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Wizzard.Engine
{
    public class Animation
    {
        public string Name { get; set; }


        private Texture2D spriteSheet;
        private Rectangle currentFrameRect;
        private int frameWidth; // Ancho de cada frame
        private int frameHeight; // Alto de cada frame
        private int totalFrames; // Total de frames en la animación
        private int currentFrame; // Frame actual
        private float frameTime;
        private float elapsedFrameTime;
        private int rowFrame;

        public Animation(Texture2D spritesheet, int frameWidth, int frameHeight, int totalFrames, float frameTime, int row)
        {
            this.spriteSheet = spritesheet;
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
            this.totalFrames = totalFrames;
            this.frameTime = frameTime;
            this.rowFrame = row;

            this.currentFrame = 0;
            elapsedFrameTime = 0f;
        }

        public void Update(GameTime gameTime)
        {
            elapsedFrameTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (elapsedFrameTime >= frameTime)
            {
                currentFrame = (currentFrame + 1) % totalFrames;
                elapsedFrameTime = 0f;
            }

            currentFrameRect = new Rectangle(currentFrame * frameWidth, rowFrame * frameHeight, frameWidth, frameHeight);
        }

        public void Draw(GameTime gameTime, Vector2 position)
        {
            Globals.Globals.SpriteBatch.Draw(this.spriteSheet, position, this.currentFrameRect, Color.White);
        }
    }
}
