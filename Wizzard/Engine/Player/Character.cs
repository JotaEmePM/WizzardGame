namespace Wizzard.Engine.Player
{
    public enum Job
    {
        Knight,
        Mage,
        Archer
    }

    public abstract class Character
    {
        public string Name { get; set; }
        public Job Job { get; set; }

        public int BaseHealth { get; set; }
        public int BaseMana { get; set; }
        public int BaseSpeed { get; set; }
        public int BaseStr { get; set; }
        public int BaseAgi { get; set; }
        public int BaseInt { get; set; }
        public int BaseVit { get; set; }
        public int BaseDex { get; set; }
        public int BaseLck { get; set; }
        public int SpritePath { get; }

    }
}
