using System;
using System.Reflection.Metadata.Ecma335;

namespace Raiding
{
    public class Rogue : BaseHero
    {
        public override int Power { get; set; } = 80;
        public Rogue(string name) : base(name)
        {

        }
        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}