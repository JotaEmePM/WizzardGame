namespace Wizzard.Engine.Interfaces
{
    public interface IUpdateableComponent
    {
        public void PreUpdate();

        public void Update();

        public void PostUpdate();
    }
}
