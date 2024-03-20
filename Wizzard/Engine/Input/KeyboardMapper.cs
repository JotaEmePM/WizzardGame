using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Wizzard.Engine.Global.Utility;
using Wizzard.Engine.Interfaces;
using IUpdateable = Wizzard.Engine.Interfaces.IUpdateable;

namespace Wizzard.Engine.Input
{
    /// <summary>
    /// Handles mapping inputs on the keyboard.
    /// </summary>
    public sealed class KeyboardMapper : IUpdateable, ICleanup
    {
        public delegate void OnInputRemapCancelled(in string inputAction);
        public event OnInputRemapCancelled InputRemapCancelledEvent = null;

        public delegate void OnInputRemapped(in string actionRemapped, in int keyMapped);
        public event OnInputRemapped InputRemappedEvent = null;

        private const double StartInputTimer = 5000d;

        private int InputIndex = 0;
        public string InputAction { get; private set; } = string.Empty;
        public double InputTimeRemaining { get; private set; } = 0d;

        public bool IsActive { get; private set; } = false;
        private Keys[] KeysToCheck = null;

        private KeyboardState KBState = default(KeyboardState);
        private KeyboardState CompareKBState = default(KeyboardState);

        public KeyboardMapper(in int inputIndex)
        {
            InputIndex = inputIndex;

            KeysToCheck = EnumUtility.GetValues<Keys>.EnumValues;
        }

        public void CleanUp()
        {
            InputRemapCancelledEvent = null;
            InputRemappedEvent = null;
        }

        public void StartMapInput(string inputAction)
        {
            InputAction = inputAction;
            InputTimeRemaining = StartInputTimer;

            KeyboardInput.UpdateKeyboardState(ref KBState);
            CompareKBState = KBState;

            IsActive = true;
        }

        public void EndMapInput()
        {
            InputTimeRemaining = 0d;
            IsActive = false;
        }

        public void Update(GameTime gameTime)
        {
            if (IsActive == false)
                return;

            InputTimeRemaining -= Time.ElapsedTime.TotalMilliseconds;

            //End if the time is up
            if (InputTimeRemaining <= 0d)
            {
                InputRemapCancelledEvent?.Invoke(InputAction);

                EndMapInput();
                return;
            }

            KeyboardInput.UpdateKeyboardState(ref CompareKBState);

            for (int i = 0; i < KeysToCheck.Length; i++)
            {
                Keys key = KeysToCheck[i];

                if (KeyboardInput.GetKeyDown(key, KBState, CompareKBState) == true)
                {
                    InputRemappedEvent?.Invoke(InputAction, (int)key);

                    EndMapInput();
                    return;
                }
            }

            KeyboardInput.UpdateKeyboardState(ref KBState);
        }
    }
}
