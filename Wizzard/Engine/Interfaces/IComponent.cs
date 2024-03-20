using System;

namespace Wizzard.Engine.Interfaces
{
    public interface IComponent
    {
        // marks if multiple instances of the same component can be assigned to an entity
        public bool UniquePerEntity { get; set; }

        public Type GetComponentType();
    }
}
