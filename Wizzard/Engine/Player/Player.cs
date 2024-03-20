using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Wizzard.Engine.Input;

namespace Wizzard.Engine.Player
{
    public enum PlayerState
    {
        Idle,
        Working_X,
        Working_Y,
        WalkLeft,
        WalkRight,
        WalkUp,
        WalkDown,
        RunLeft,
        RunRight,
        RunUp,
        RunDown,
        DashLeft,
        DashRight,
        DashUp,
        DashDown,
        AttackLeft, AttackRight,
        AttackUp, AttackDown,
        CastLeft, CastRight,
        CastUp, CastDown,
        Die,
        Eat,
        Cure,
        Grab,
        Hurt_X,
        Hurt_Y
    }

    public enum PlayerDirection
    {
        Left, Right
    }

    public class Player : Character
    {
        private string job_sprite_path;

        public List<Animation> Animations;
        public Animation CurrentAnimation;

        UserInputController UserInput;
        public PlayerState CurrentState { get; set; }
        private Vector2 Position { get; set; }
        private bool InMovement = false;


        public Player(string name, Job job)
        {
            this.Name = name;
            this.Job = Job;

            this.CurrentState = PlayerState.Idle;

            SetupAnimations();

            this.Position = new Vector2(50, 50);

            SetupController();
        }

        public void SetupController()
        {
            UserInput = new UserInputController();
            UserInput.RegisterKeyPressAction(Keys.W, MoveUp);
            UserInput.RegisterKeyPressAction(Keys.A, MoveLeft);
            UserInput.RegisterKeyPressAction(Keys.S, MoveDown);
            UserInput.RegisterKeyPressAction(Keys.D, MoveRight);
        }

        public void MoveUp()
        {
            this.Position = new Vector2(this.Position.X, this.Position.Y - 1);
            this.CurrentState = PlayerState.WalkUp;
            ChangeAnimation("Walk");
        }

        public void MoveDown()
        {
            this.Position = new Vector2(this.Position.X, this.Position.Y + 1);
            this.CurrentState = PlayerState.WalkDown;
            InMovement = true;
            ChangeAnimation("Walk");
        }

        public void MoveLeft()
        {
            this.Position = new Vector2(this.Position.X - 1, this.Position.Y);
            this.CurrentState = PlayerState.WalkLeft;
            InMovement = true;
            ChangeAnimation("Walk");
        }

        public void MoveRight()
        {
            this.Position = new Vector2(this.Position.X + 1, this.Position.Y);
            this.CurrentState = PlayerState.WalkRight;
            InMovement = true;
            ChangeAnimation("Walk");
        }


        public void SetupAnimations()
        {
            switch (this.Job)
            {
                case Job.Knight:
                    this.job_sprite_path = "Sprites/player/Hero_01";
                    break;
                case Job.Archer:
                    this.job_sprite_path = "Sprites/player/Hero_02";
                    break;
                case Job.Mage:
                    this.job_sprite_path = "Sprites/player/Hero_03";
                    break;
            }

            Animations = new();
            // Idle
            var player_idle_spritesheet = Globals.Globals.ContentManager.Load<Texture2D>(this.job_sprite_path);
            Animations.Add(new Animation(player_idle_spritesheet, 96, 96, 6, 0.1f, 0)
            {
                Name = "Idle"
            });

            var player_walk_down_spritesheet = Globals.Globals.ContentManager.Load<Texture2D>(this.job_sprite_path);
            Animations.Add(new Animation(player_walk_down_spritesheet, 96, 96, 6, 0.1f, 1)
            {
                Name = "Walk"
            });

            InMovement = false;
            ChangeAnimation("Idle");
        }

        public void ChangeAnimation(string name)
        {
            if (CurrentAnimation != null)
            {
                var newAnimation = Animations.Find(a => a.Name == name);
                if (newAnimation != null)
                    CurrentAnimation = newAnimation;
            }
            else
            {
                CurrentAnimation = Animations[0];
            }
        }


        public void Update(GameTime gameTime)
        {
            InMovement = false;
            if (Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.S))
            {
                MoveDown();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.W))
            {
                MoveUp();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A))
            {
                MoveLeft();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
            {
                MoveRight();
            }

            if (!InMovement)
                ChangeAnimation("Idle");
            CurrentAnimation.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            CurrentAnimation.Draw(gameTime, this.Position);
        }
    }
}
