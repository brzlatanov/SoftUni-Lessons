namespace Raiding
{
    public abstract class BaseHero
    {
        public virtual string Name { get; set; }
        public virtual int Power { get; set; }

        public BaseHero(string name)
        {
            this.Name = name;
        }
        public abstract string CastAbility();
    }
}