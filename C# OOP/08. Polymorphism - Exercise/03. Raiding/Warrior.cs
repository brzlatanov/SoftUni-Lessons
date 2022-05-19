namespace Raiding
{
    public class Warrior : Rogue
    {
        public override int Power { get; set; } = 100;
        public Warrior(string name) : base(name)
        {

        }
    }
}