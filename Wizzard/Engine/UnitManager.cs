using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Wizzard.Engine.Controls;

namespace Wizzard.Engine
{
    public class UnitManager
    {
        public readonly List<Unit> _units;
        public readonly List<BaseControl> _controls;
        public UnitManager()
        {
            _units = new List<Unit>();
            _controls = new();
        }

        public void Add(Unit unit)
        {
            _units.Add(unit);
        }

        public void Add(BaseControl control)
        {
            _controls.Add(control);
        }

        public void Remove(Unit unit)
        {
            _units.Remove(unit);
        }

        public void Remove(BaseControl control)
        {
            _controls.Remove(control);
        }

        public void ClearUnits()
        {
            _units.Clear();
        }

        public void ClearControls()
        {
            _controls.Clear();
        }

        public bool Contains(Unit unit)
        {
            return _units.Contains(unit);
        }

        public bool Contains(BaseControl control)
        {
            return _controls.Contains(control);
        }

        public void Load()
        {
            foreach (var unit in _units)
            {
                if (unit != null)
                    unit.LoadContent();
            }

            foreach (var control in _controls)
            {
                if (control != null)
                    control.LoadContent();
            }
        }

        public void Update(GameTime gametime)
        {
            foreach (Unit unit in _units)
            {
                if (unit != null)
                    unit.Update(gametime);
            }

            foreach (var control in _controls)
            {
                if (control != null)
                    control.Update(gametime);
            }
        }

        public void Draw(GameTime gameTime)
        {
            foreach (Unit unit in _units)
            {
                if (unit != null)
                    unit.Draw(gameTime);
            }

            foreach (var control in _controls)
            {
                if (control != null)
                    control.Draw(gameTime);
            }
        }

        public void Unload()
        {
            ClearUnits();
            ClearControls();
        }
    }
}
